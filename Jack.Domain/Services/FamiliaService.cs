using Jack.Domain.Entity;
using Jack.Domain.Enum;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using Jack.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Domain.Services
{
    public class FamiliaService : ServiceBase<Familia>, IFamiliaService
    {

        private readonly IFamiliaRepository repFamilia;
        private readonly INivelRepository repNivel;
        private readonly IStatusFamiliaRepository repStatus;
        private readonly IStatusCriancaRepository repStatusCrianca;
        private readonly IReuniaoRepository repReuniao;
        private readonly IPresencaRepository repPresenca;
        private readonly ValidationResult validationResult = new ValidationResult();
        private readonly ILogRepository repLog;
        private Parametro Parametro { get; set; }

        public FamiliaService(IFamiliaRepository repFamilia,
                              INivelRepository repNivel,
                              IStatusFamiliaRepository repStatus,
                              IStatusCriancaRepository repStatusCrianca,
                              IReuniaoRepository repReuniao,
                              IPresencaRepository repPresenca,
                              IParametroRepository repParametros,
                              ILogRepository repLog)
            : base(repFamilia)
        {
            this.repFamilia = repFamilia;
            this.repNivel = repNivel;
            this.repStatus = repStatus;
            this.repStatusCrianca = repStatusCrianca;
            this.repReuniao = repReuniao;
            this.repPresenca = repPresenca;
            this.repLog = repLog;
            Parametro = repParametros.Obter();
        }
        public IEnumerable<Familia> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Nome.ToLower().Contains(nome.ToLower())).OrderBy(f => f.Nome).ToList();
            return registros;
        }

        public new IEnumerable<Familia> ObterTodos()
        {
            var registros = base.ObterTodos().OrderBy(f => f.Nome);
            return registros;
        }

        public ValidationResult Gravar(Familia item)
        {
            if (item.Codigo == 0)
            {
                item.DataCriacao = DateTime.Now;
                item.DataAtualizacao = DateTime.Now;
                Adicionar(item);
            }
            else
            {
                var familia = ObterPorId(item.Codigo);
                if (item.DataCriacao.Year == 1)
                {
                    item.DataCriacao = DateTime.Now;
                }
                item.DataAtualizacao = DateTime.Now;
                item.Criancas = familia.Criancas;
                item.Representantes = familia.Representantes;
                item.Sacolas = familia.Sacolas;
                item.Presencas = familia.Presencas;
                Atualizar(item);
            }

            return validationResult;
        }

        public ValidationResult Gravar(Familia item, int reuniao)
        {
            var reuniaoPresenca = repReuniao.ObterPorId(reuniao);

            if (reuniaoPresenca == null)
            {
                validationResult.Add(new ValidationError("Reunião não encontrada"));
                return validationResult;
            }

            item.DataCriacao = DateTime.Now;
            item.DataAtualizacao = DateTime.Now;
            Adicionar(item);

            var presenca = new Presenca
            {
                Familia = item,
                Reuniao = reuniaoPresenca
            };

            repPresenca.Adicionar(presenca);

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }

            repFamilia.Excluir(item);

            return validationResult;

        }

        #region Validações

        public void AtualizarFamilias()
        {
            var familias = ObterTodos().ToList();
            foreach (var familiaItem in familias)
            {
                AtualizarFamilia(familiaItem, true);
            }
        }

        public ValidationResult AtualizarFamilia(int id, bool gravar = true)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Família não encontrada"));
                return validationResult;
            }

            AtualizarFamilia(item, gravar);

            return validationResult;

        }

        public Familia AtualizarFamilia(Familia familia, bool gravar = true)
        {
            // sem crianças
            if (!familia.TemCriancas())
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemCrianca);
                if (gravar)
                {
                    Gravar(familia);
                }
                AddLog(familia.Codigo, EnumStatusFamilia.FamiliaSemCrianca.Int(), "AtualizarFamilia", "Familia Sem Criança");

                return familia;
            }

            // com crianças, mas todas maiores ou inelegíveis
            if (familia.TemCriancasMaiores())
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemCrianca);
                if (gravar)
                {
                    Gravar(familia);
                }
                AddLog(familia.Codigo, EnumStatusFamilia.FamiliaSemCrianca.Int(), "AtualizarFamilia", "Familia Sem Criança");
                return familia;
            }

            //sem Documentacao
            if (!familia.TemDocumentacaoTodasCriancas())
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemDocumentacao);
                if (gravar)
                {
                    Gravar(familia);
                }
                AddLog(familia.Codigo, EnumStatusFamilia.FamiliaSemDocumentacao.Int(), "AtualizarFamilia", "Familia Sem Documentação");
                return familia;
            }
            if (familia.PresencaJustificada)
            {
                familia.Nivel = repNivel.ObterPorId(1);
                AtualizarPresencas(familia);
                return familia;
            }

            //sem presença
            if (familia.FamiliaSemPresenca())
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemPresenca);
                AddLog(familia.Codigo, EnumStatusFamilia.FamiliaSemPresenca.Int(), "AtualizarFamilia", "Familia Sem Presença");
                return familia;
            }

            AtualizaNivel(ref familia);

            //representantes 
            AtualizaStatusPorRepresentante(ref familia);

            //Criancas
            AtualizaStatusPorCrianca(ref familia);

            if (gravar)
            {
                Atualizar(familia);
            }
            return familia;
        }

        private bool FamiliaComCriancasEmExcesso(int status)
        {
            return status == EnumStatusFamilia.CriancasExcedido.Int();
        }

        private bool FamiliaRepresentanteEmExcesso(int status)
        {
            return status == EnumStatusFamilia.RepresentanteExcedido.Int();
        }

        private void AtualizaStatusPorRepresentante(ref Familia familia)
        {
            if (familia.PermiteExcedenteRepresentantes)
            {
                return;
            }
            var quantidadeRepresentantesLimitada = familia.Representantes.Where(r => !r.TipoParentesco.Parente).ToList().Count;
            var limiteRepresantante = Parametro.NumeroMaximoRepresentantes;

            if (limiteRepresantante >= quantidadeRepresentantesLimitada) return;

            if (FamiliaComCriancasEmExcesso(familia.Status.Codigo))
            {
                familia.Status = repStatus.ObterPorId(EnumStatusFamilia.CriancasERepresentanteExcedido.Int());
                AddLog(familia.Codigo, EnumStatusFamilia.CriancasERepresentanteExcedido.Int(), "AtualizaStatusPorRepresentante", "Quantidade de Representantes e Crianças Excedida");
            }
            else
            {
                familia.Status = repStatus.ObterPorId(EnumStatusFamilia.RepresentanteExcedido.Int());
                AddLog(familia.Codigo, EnumStatusFamilia.RepresentanteExcedido.Int(), "AtualizaStatusPorRepresentante", "Quantidade de Representantes Excedida");
            }

        }

        private void AtualizaStatusPorCrianca(ref Familia familia)
        {
            //pode exceder crianças sem problemas
            if (familia.PermiteExcedenteCriancas)
            {
                return;
            }
            var quantidadeCriancaLimitada = familia.Criancas
                                                   .Where(r => r.TipoParentesco.GrauParentesco != EnumGrauParentesco.PrimeiroGrau.Int()
                                                          && r.Status.PermiteSacola).ToList().Count;

            var quantidadeCrianca = familia.Criancas.Where(c => c.Status.PermiteSacola).ToList().Count;
            var quantidadedeCriancaGrauParentescoUm = quantidadeCrianca - quantidadeCriancaLimitada;

            var limiteCrianca = Parametro.NumeroMaximoCricancas;

            //se a quantidade de crianças é inferior ao limite, nem precisa fazer nada.
            if (limiteCrianca >= quantidadeCrianca) return;

            if (FamiliaRepresentanteEmExcesso(familia.Status.Codigo))
            {
                familia.Status = repStatus.ObterPorId(EnumStatusFamilia.CriancasERepresentanteExcedido.Int());
                AddLog(familia.Codigo, EnumStatusFamilia.CriancasERepresentanteExcedido.Int(), "AtualizaStatusPorCrianca", "Quantidade de Representantes e Crianças Excedida");

            }
            else
            {
                familia.Status = repStatus.ObterPorId(EnumStatusFamilia.CriancasExcedido.Int());
                AddLog(familia.Codigo, EnumStatusFamilia.CriancasExcedido.Int(), "AtualizaStatusPorCrianca", "Quantidade de Crianças Excedida");
            }

            // vamos tratar as crianças excedentes!
            if (FamiliaComCriancasEmExcesso(familia.Status.Codigo))
            {
                ResolverCriancasAMais(ref familia, quantidadeCriancaLimitada, quantidadeCrianca);
            }
        }

        public void ResolverCriancasAMais(ref Familia familia, int quantidadeLimitada, int quantidadeCriancas)
        {
            var quantidadedeCriancaGrauParentescoUm = quantidadeCriancas - quantidadeLimitada;
            var quantidadeQuePode = 0;
            var quantidadeARemover = 0;

            //se a quantidade de filhos for maior que o limite
            if (Parametro.NumeroMaximoCricancas < quantidadedeCriancaGrauParentescoUm)
            {
                var criancasGrauUm = familia.Criancas.Where(c => c.TipoParentesco.GrauParentesco == 1
                                                            && c.Status.PermiteSacola).ToList();
                quantidadeARemover = quantidadedeCriancaGrauParentescoUm - Parametro.NumeroMaximoCricancas;
                var criancasAAlterarGrauUm = criancasGrauUm.OrderBy(c => c.MedidaIdade)
                                                           .ThenByDescending(c => c.Idade)
                                                           .Take(quantidadeARemover);
                foreach (var criancaAlterar in criancasAAlterarGrauUm)
                {
                    criancaAlterar.Status = repStatusCrianca.ObterPorId(EnumStatusCrianca.CriancaExcedente.Int());
                    AddLog(criancaAlterar.Codigo, EnumStatusCrianca.CriancaExcedente.Int(), "ResolverCriancasAMais", "Criança Removida da Sacola. Excedente. Grau Parentesco = 1");
                }
            }

            quantidadeQuePode = Parametro.NumeroMaximoCricancas - quantidadedeCriancaGrauParentescoUm;
            quantidadeARemover = quantidadeLimitada - quantidadeQuePode;

            //crianças que não são de grau de parentesco == 1. Serão Retiradas
            var criancasGrauDiferente = familia.Criancas.Where(c => c.TipoParentesco.GrauParentesco > 1
                                                               && c.Status.PermiteSacola).ToList();
            var criancasParaAlterar = criancasGrauDiferente.OrderBy(c => c.MedidaIdade)
                                                           .ThenByDescending(c => c.Idade)
                                                           .Take(quantidadeARemover);

            foreach (var criancaAlterar in criancasParaAlterar)
            {
                criancaAlterar.Status = repStatusCrianca.ObterPorId(EnumStatusCrianca.CriancaExcedente.Int());
                AddLog(criancaAlterar.Codigo, EnumStatusCrianca.CriancaExcedente.Int(), "ResolverCriancasAMais", "Criança Removida da Sacola. Excedente. Grau Parentesco > 1");
            }
            //criancasParaAlterar.ToList().ForEach(
            // c => c.Status = repStatusCrianca.ObterPorId(EnumStatusCrianca.CriancaExcedente.Int()));

        }

        public void AtualizaNivel(ref Familia familia)
        {

            var ano = DateTime.Now.Year;

            var reunioesFeitas = ObterQuantidadeReunioesAno(ano);
            var qtdePresencas = ObterQuantidadePresencas(familia.Presencas, ano);
            var percPresenca = (qtdePresencas / reunioesFeitas) * 100;

            familia.Nivel = repNivel.ObterNivelPorFaixaPresencial(percPresenca);
            if (familia.Nivel.Codigo == 99)
            {
                familia.Status = repStatus.ObterPorId(EnumStatusFamilia.FamiliaSemPresenca.Int());
            }
            else
            {
                familia.Status = repStatus.ObterPorId(EnumStatusFamilia.DadosOk.Int());
            }

        }

        public ValidationResult AtualizarPresencas(Familia familia)
        {
            var data = DateTime.Now;
            var ano = data.Month < 8 ? data.Year : data.Year + 1;

            var reunioes = repReuniao.ObterTodosAteHoje(ano, data);
            foreach (var reuniao in reunioes)
            {
                var presenca = new Presenca
                {
                    Familia = familia,
                    Reuniao = reuniao
                };
                repPresenca.Adicionar(presenca);
            }
            return validationResult;
        }

        private float ObterQuantidadeReunioesAno(int ano)
        {
            var reunioes = repReuniao.ObterTodos()
                                     .Where(r => r.AnoCorrente == ano
                                               && r.Data <= DateTime.Now)
                                     .ToList().Count;

            return reunioes;

        }

        private float ObterQuantidadePresencas(IList<Presenca> presencas, int ano)
        {
            return presencas.Where(p => p.Reuniao.AnoCorrente == ano).ToList().Count;
        }

        private void AtualizarFamiliaNivel99(ref Familia familia, EnumStatusFamilia status)
        {
            familia.Nivel = repNivel.ObterPorId(99);
            familia.Status = repStatus.ObterPorId(status.Int());
            familia.Consistente = false;
            familia.Sacolinha = false;
            familia.DataAtualizacao = DateTime.Now;
        }

        #endregion

        #region Log

        private void AddLog(int codigo, int status, string processo, string mensagem)
        {
            var log = new Log
            {
                Codigo = codigo,
                StatusEntidade = status,
                Mensagem = mensagem,
                Processo = processo,
                Data = DateTime.Now,
                Entidade = "Familia"
            };

            repLog.Adicionar(log);
        }

        #endregion

    }
}