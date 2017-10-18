using Jack.Domain.Entity;
using Jack.Domain.Enum;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using Jack.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
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
        public IEnumerable<Familia> ObterPorStatus(int status)
        {
            var registros = ObterTodos()
                                .Where(f => f.Status.Codigo == status)
                                .OrderBy(f => f.Nome).ToList();
            return registros;
        }
        public IEnumerable<Familia> ObterNaoSacolas()
        {
            var registros = ObterTodos()
                                .Where(f => !f.Status.PermiteSacola)
                                .OrderBy(f => f.Nome).ToList();
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
                if (familia.FamiliaBanida())
                {
                    validationResult.AddError("Não é possível alterar esta família, Status 13. Banida.");
                    return validationResult;
                }

                if (item.DataCriacao.Year == 1)
                {
                    item.DataCriacao = DateTime.Now;
                }

                familia.DataAtualizacao = DateTime.Now;
                familia.BlackListPasso1 = item.BlackListPasso1;
                familia.BlackListPasso2 = item.BlackListPasso2;
                familia.Consistente = item.Consistente;
                familia.Contato = item.Contato;
                familia.Fake = item.BlackListPasso2;
                familia.Nome = item.Nome;
                familia.PermiteExcedenteCriancas = item.PermiteExcedenteCriancas;
                familia.PermiteExcedenteRepresentantes = item.PermiteExcedenteRepresentantes;
                familia.PresencaJustificada = item.PresencaJustificada;
                familia.Sacolinha = item.Sacolinha;
                familia.Nivel = item.Nivel;

                if (!familia.IsValid())
                {
                    return familia.ValidationResult;
                }
                Atualizar(familia);
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
            //Alteração, para familia status 13, Banida, não pode fazer nada, nem mexer.
            var familias = ObterTodos().Where(f => f.Status.Codigo != EnumStatusFamilia.FamiliaBanidaPorProblemas.Int()).ToList();
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
            //Observar o STATUS
            if (familia.FamiliaEmInvestigacao())
            {
                AddLog(familia.Codigo, EnumStatusFamilia.FamiliaBanidaPorProblemas.Int(), nameof(AtualizarFamilia), "Familia Banida.Não pode atualizar");
                return familia;
            }

            //Observar o STATUS
            if (familia.FamiliaBanida())
            {
                AddLog(familia.Codigo, EnumStatusFamilia.FamiliaBanidaPorProblemas.Int(), nameof(AtualizarFamilia), "Familia Banida.Não pode atualizar");
                return familia;
            }

            // sem crianças..
            if ((!familia.TemCriancas()) && (familia.Representantes.Count == 0))
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemCrianca);
                if (gravar)
                {
                    Gravar(familia);
                }
                AddLog(familia.Codigo, EnumStatusFamilia.FamiliaSemCrianca.Int(), nameof(AtualizarFamilia), "Familia Sem Criança");

                return familia;
            }

            // com crianças, mas todas maiores ou inelegíveis
            if ((familia.TemCriancasMaiores()) && (familia.Representantes.Count == 0))
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemCrianca);
                if (gravar)
                {
                    Gravar(familia);
                }
                AddLog(familia.Codigo, EnumStatusFamilia.FamiliaSemCrianca.Int(), nameof(AtualizarFamilia), "Familia Sem Criança");
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
                AddLog(familia.Codigo, EnumStatusFamilia.FamiliaSemDocumentacao.Int(), nameof(AtualizarFamilia), "Familia Sem Documentação");
                return familia;
            }
            if (familia.PresencaJustificada)
            {
                familia.Nivel = repNivel.ObterPorId(1);
                familia.Status = ObterStatus(EnumStatusFamilia.DadosOk.Int()); // ok
                AtualizarPresencas(familia);
                if (gravar)
                {
                    Atualizar(familia);
                }
                return familia;
            }

            //sem presença
            if (familia.FamiliaSemPresenca())
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemPresenca);
                AddLog(familia.Codigo, EnumStatusFamilia.FamiliaSemPresenca.Int(), nameof(AtualizarFamilia), "Familia Sem Presença");
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

        public ValidationResult AtualizarSimSacola(int familiaId)
        {
            var familia = repFamilia.ObterPorId(familiaId);
            if (familia == null)
            {
                validationResult.Add(new ValidationError("Família não encontrada"));
                return validationResult;
            }

            familia.Sacolinha = true;
            Atualizar(familia);
            return validationResult;

        }
        public void RemoverCriancasDiferentesDoGrauUm(ref Familia familia)
        {
            var criancas = familia.Criancas.Where(c => c.TipoParentesco.GrauParentesco != EnumGrauParentesco.PrimeiroGrau.Int()).ToList();
            {
                foreach (var crianca in criancas)
                {
                    crianca.Status = ObterStatusCrianca(EnumStatusCrianca.CriancaExcedente.Int());
                    AddLog(crianca.Codigo, EnumStatusCrianca.CriancaExcedente.Int(), nameof(ResolverCriancasAMais), "Criança Removida da Sacola. Excedente. Grau Parentesco diferente de 1");
                }
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
                    criancaAlterar.Status = ObterStatusCrianca(EnumStatusCrianca.CriancaExcedente.Int());
                    AddLog(criancaAlterar.Codigo, EnumStatusCrianca.CriancaExcedente.Int(), nameof(ResolverCriancasAMais), "Criança Removida da Sacola. Excedente. Grau Parentesco = 1");
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
                criancaAlterar.Status = ObterStatusCrianca(EnumStatusCrianca.CriancaExcedente.Int());
                AddLog(criancaAlterar.Codigo, EnumStatusCrianca.CriancaExcedente.Int(), nameof(ResolverCriancasAMais), "Criança Removida da Sacola. Excedente. Grau Parentesco > 1");
            }
            //criancasParaAlterar.ToList().ForEach(
            // c => c.Status = ObterStatusCrianca(EnumStatusCrianca.CriancaExcedente.Int()));

        }

        public void AtualizaNivel(ref Familia familia)
        {
            //TODO: Observar para preparar para o nível 6
            //TODO: Não deixar nivel 98 ir para sacola.
            var ano = DateTime.Now.Year;

            var reunioesFeitas = ObterQuantidadeReunioesAno(ano);
            var qtdePresencas = ObterQuantidadePresencas(familia.Presencas, ano);
            var percPresenca = (qtdePresencas / reunioesFeitas) * 100;

            familia.Nivel = repNivel.ObterNivelPorFaixaPresencial(percPresenca);
            if (familia.Nivel.Codigo == 99)
            {
                familia.Status = ObterStatus(EnumStatusFamilia.FamiliaSemPresenca.Int());
            }
            else
            {
                familia.Status = ObterStatus(EnumStatusFamilia.DadosOk.Int());
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

        public IEnumerable<Familia> ObterFamiliasBanidas()
        {
            return ObterPorStatus(EnumStatusFamilia.FamiliaBanidaPorProblemas.Int());
        }

        public ValidationResult AtualizarFamiliaParaBanida(int familiaId)
        {
            var familia = ObterPorId(familiaId);
            if (familia == null)
            {
                validationResult.AddError("Familia não encontrada");
                return validationResult;
            }
            familia.Status = ObterStatus(EnumStatusFamilia.FamiliaBanidaPorProblemas.Int());

            //método herdado por que o atual não deixa grava e fazer nada com familia status 13
            base.Atualizar(familia);

            return validationResult;
        }


        public ValidationResult LiberarFamiliaBanida(int familiaId)
        {
            var familia = ObterPorId(familiaId);
            if (familia == null)
            {
                validationResult.AddError("Familia não encontrada");
                return validationResult;
            }
            familia.Status = ObterStatus(EnumStatusFamilia.DadosOk.Int());

            //uso o atualizar por que ele vai analisar a familia, e por ela no status correto
            // analisa e grava.
            AtualizarFamilia(familia);

            return validationResult;
        }


        #region Private Metodos

        private void AtualizaStatusPorRepresentante(ref Familia familia)
        {
            //rever
            if (familia.PermiteExcedenteRepresentantes)
            {
                var limite = Parametro.NumeroMaximoCricancasRepresentantes;
                //if (FamiliaComCriancasDeRepresentanteExcedida(familia))
                if (familia.FamiliaComCriancasDeRepresentanteExcedida(limite))
                {
                    familia.Status = ObterStatus(EnumStatusFamilia.CriancasDaFamilaEDoRepresentanteExcedido.Int());
                    AddLog(familia.Codigo, EnumStatusFamilia.CriancasDaFamilaEDoRepresentanteExcedido.Int(), nameof(AtualizaStatusPorRepresentante), "Quantidade de Crianças da Familia com as da Representantes foram Excedidas");
                }
                return;
            }
            var quantidadeRepresentantesLimitada = familia.Representantes.Where(r => !r.TipoParentesco.Parente).ToList().Count;
            var limiteRepresantante = Parametro.NumeroMaximoRepresentantes;

            if (limiteRepresantante >= quantidadeRepresentantesLimitada) return;

            //if (FamiliaComCriancasEmExcesso(familia.Status.Codigo))
            if (familia.FamiliaComCriancasEmExcesso())
            {
                familia.Status = ObterStatus(EnumStatusFamilia.CriancasERepresentanteExcedido.Int());
                AddLog(familia.Codigo, EnumStatusFamilia.CriancasERepresentanteExcedido.Int(), nameof(AtualizaStatusPorRepresentante), "Quantidade de Representantes e Crianças Excedida");
            }
            else
            {
                familia.Status = ObterStatus(EnumStatusFamilia.RepresentanteExcedido.Int());
                AddLog(familia.Codigo, EnumStatusFamilia.RepresentanteExcedido.Int(), nameof(AtualizaStatusPorRepresentante), "Quantidade de Representantes Excedida");
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

            if (quantidadedeCriancaGrauParentescoUm > limiteCrianca)
            {
                if (Parametro.PodeUltrapassarNumeroMaximoFilhos)
                {
                    //OK Grau Um pode exceder, mas rerão removidos outros
                    RemoverCriancasDiferentesDoGrauUm(ref familia);
                    return;
                }
            }

            //if (FamiliaRepresentanteEmExcesso(familia.Status.Codigo))
            if (familia.FamiliaRepresentanteEmExcesso())
            {
                familia.Status = ObterStatus(EnumStatusFamilia.CriancasERepresentanteExcedido.Int());
                AddLog(familia.Codigo, EnumStatusFamilia.CriancasERepresentanteExcedido.Int(), nameof(AtualizaStatusPorCrianca), "Quantidade de Representantes e Crianças Excedida");

            }
            else
            {
                familia.Status = ObterStatus(EnumStatusFamilia.CriancasExcedido.Int());
                AddLog(familia.Codigo, EnumStatusFamilia.CriancasExcedido.Int(), nameof(AtualizaStatusPorCrianca), "Quantidade de Crianças Excedida");
            }

            // vamos tratar as crianças excedentes!
            //if (FamiliaComCriancasEmExcesso(familia.Status.Codigo))
            if (familia.FamiliaComCriancasEmExcesso())
            {
                ResolverCriancasAMais(ref familia, quantidadeCriancaLimitada, quantidadeCrianca);
            }
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
            //se familia tem presenças: Status 98, se não 99

            if (familia.Presencas.Any(p => p.Reuniao.AnoCorrente == DateTime.Now.Year))
            {
                familia.Nivel = repNivel.ObterPorId(EnumNivel.Nivel98.Int());
            }
            else
            {
                familia.Nivel = repNivel.ObterPorId(EnumNivel.Nivel99.Int());
            }
            familia.Status = ObterStatus(status.Int());
            familia.Consistente = false;
            familia.Sacolinha = false;
            familia.DataAtualizacao = DateTime.Now;
        }

        private StatusFamilia ObterStatus(int statusId)
        {
            var status = repStatus.ObterPorId(statusId);
            return status;

        }

        private StatusFamilia ObterStatus(EnumStatusFamilia statusEnum)
        {
            var status = ObterStatus(statusEnum.Int());
            return status;

        }

        private StatusCrianca ObterStatusCrianca(int statusId)
        {
            var status = repStatusCrianca.ObterPorId(statusId);
            return status;

        }

        private StatusCrianca ObterStatusCrianca(EnumStatusFamilia statusEnum)
        {
            var status = ObterStatusCrianca(statusEnum.Int());
            return status;

        }

        #endregion

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
                Entidade = nameof(Familia)
            };

            repLog.Adicionar(log);
        }

        #endregion

    }
}