using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Enum;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using Jack.Extensions;

namespace Jack.Domain.Services
{
    public class FamiliaService : ServiceBase<Familia>, IFamiliaService
    {

        private readonly IFamiliaRepository repFamilia;
        private readonly INivelRepository repNivel;
        private readonly IStatusFamiliaRepository repStatus;
        private readonly IReuniaoRepository repReuniao;
        private readonly IPresencaRepository repPresenca;
        private readonly IParametroRepository repParametros;
        private readonly ValidationResult validationResult = new ValidationResult();
        private Parametro Parametro {get; set;}

        public FamiliaService(IFamiliaRepository repFamilia,
                              INivelRepository repNivel,
                              IStatusFamiliaRepository repStatus,
                              IReuniaoRepository repReuniao,
                              IPresencaRepository repPresenca,
                              IParametroRepository repParametros)
            : base(repFamilia)
        {
            this.repFamilia = repFamilia;
            this.repNivel = repNivel;
            this.repStatus = repStatus;
            this.repReuniao = repReuniao;
            this.repPresenca = repPresenca;
            this.repParametros = repParametros;
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

            AtualizarFamilia(item, true);
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

            AtualizarFamilia(item, true);

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
                return familia;
            }

            AtualizaNivel(ref familia);

            //representantes 
            AtualizaStatusPorRepresentante(ref familia);

            //Criancas
            AtualizaStatusPorCrianca(ref familia);

            if (gravar)
            {
                Gravar(familia);
            }
            return familia;
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

            if (familia.Status.Codigo == (int)EnumStatusFamilia.CriancasExcedido)
            {
                familia.Status = repStatus.ObterPorId((int)EnumStatusFamilia.CriancasERepresentanteExcedido);
            }
            else
            {
                familia.Status = repStatus.ObterPorId((int)EnumStatusFamilia.RepresentanteExcedido);
            }

        }

        private void AtualizaStatusPorCrianca(ref Familia familia)
        {
            if (familia.PermiteExcedenteCriancas)
            {
                return;
            }
            var quantidadeCriancaLimitada = familia.Criancas.Where(r => !r.TipoParentesco.Parente).ToList().Count;
            var limiteCrianca = Parametro.NumeroMaximoCricancas;

            if (limiteCrianca >= quantidadeCriancaLimitada) return;

            if (familia.Status.Codigo == (int)EnumStatusFamilia.RepresentanteExcedido)
            {
                familia.Status = repStatus.ObterPorId((int)EnumStatusFamilia.CriancasERepresentanteExcedido);
            }
            else
            {
                familia.Status = repStatus.ObterPorId((int)EnumStatusFamilia.CriancasExcedido);
            }

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
                familia.Status = repStatus.ObterPorId((int)EnumStatusFamilia.FamiliaSemPresenca);    
            }
            else
            {
                familia.Status = repStatus.ObterPorId((int)EnumStatusFamilia.DadosOk);    
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
                    Familia = familia, Reuniao = reuniao
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

    }
}