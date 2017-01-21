using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Enum;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;
using Jack.Extensions;

namespace Jack.Domain.Services
{

    public class CriancaService : ServiceBase<Crianca>, ICriancaService
    {

        private readonly ICriancaRepository repCrianca;
        private readonly IFamiliaRepository repFamilia;
        private readonly IStatusCriancaRepository repStatus;
        private readonly IKitRepository repKit;
        private readonly ICalcadoRepository repCalcado;
        private readonly IRoupaRepository repRoupa;
        private readonly IParametroRepository repParametros;
        private readonly ISacolaRepository repSacola;

        private readonly ValidationResult validationResult = new ValidationResult();

        public CriancaService(ICriancaRepository repCrianca,
                              IFamiliaRepository repFamilia,
                              IStatusCriancaRepository repStatus,
                              IKitRepository repKit,
                              ICalcadoRepository repCalcado,
                              IRoupaRepository repRoupa,
                              IParametroRepository repParametros,
                              ISacolaRepository repSacola)
            : base(repCrianca)
        {
            this.repCrianca = repCrianca;
            this.repFamilia = repFamilia;
            this.repStatus = repStatus;
            this.repKit = repKit;
            this.repCalcado = repCalcado;
            this.repRoupa = repRoupa;
            this.repParametros = repParametros;
            this.repSacola = repSacola;
        }

        public IEnumerable<Crianca> ObterCriancas(int familia)
        {
            var registros = Pesquisar(p => p.Familia.Codigo == familia).OrderBy(c => c.Nome).ToList();
            return registros;
        }

        public IEnumerable<Crianca> ObterCriancasSacola(int familia)
        {
            var registros = Pesquisar(p => p.Familia.Codigo == familia).ToList();
            var sacolasFamilia = repSacola.ObterTodos().Where(s => s.Familia.Codigo == familia).ToList();

            foreach (var crianca in registros)
            {
                crianca.Sacolinha = sacolasFamilia.Any(s => s.Crianca.Codigo == crianca.Codigo);
            }

            return registros.OrderBy(c => c.Nome).ToList();
        }

        public ValidationResult Gravar(Crianca item)
        {
            //acerto de dados
            item.Familia = repFamilia.ObterPorId(item.Familia.Codigo);
            item.Status = repStatus.ObterPorId(item.Status.Codigo);
            item.Kit = repKit.ObterPorId(item.Kit.Codigo);
            item.DataAtualizacao = DateTime.Now;
            
            if (item.Codigo == 0)
            {
                item.DataCriacao = DateTime.Now;
                Adicionar(item);
            }
            else
            {
                item.DataCriacao = ObterPorId(item.Codigo).DataCriacao;
                Atualizar(item);
            }

            return validationResult;
        }

        public ValidationResult GravarVestimentas(int crianca, int calcado, string roupa)
        {
            var item = repCrianca.ObterPorId(crianca);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }
            item.Roupa = roupa;
            item.Calcado = calcado;

            Atualizar(item);
            
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

            repCrianca.Excluir(item);

            return validationResult;

        }

        public bool ValidaCalcado(string sexo, int idade, string medidaIdade, int calcado)
        {
            var limite = repParametros.Obter().CalcadoLimite;
            var calcadoPadrao = repCalcado.ObterPorSexoIdade(sexo, idade, medidaIdade);

            var diferenca = (uint)calcadoPadrao - calcado;

            return (diferenca > limite);
        }

        public bool ValidaRoupa(string sexo, int idade, string medidaIdade, bool isCriancaGrande, string roupa)
        {
            var roupaDado = repRoupa.ObterPorIdade(idade, medidaIdade);
            var roupaDadoIdadeAcima = repRoupa.ObterPorIdade(idade + 1, medidaIdade);

            string roupaPadrao;
            string roupaPadraoIdadeAcima;
            var retorno = false;

            if (isCriancaGrande)
            {
                roupaPadrao = roupaDado.RoupaGrande;
                roupaPadraoIdadeAcima = roupaDadoIdadeAcima.RoupaGrande;
            }
            else
            {
                roupaPadrao = roupaDado.Roupa;
                roupaPadraoIdadeAcima = roupaDadoIdadeAcima.Roupa;
            }

            //verificar os tamanhos.
            if (roupa == roupaPadrao)
            {
                retorno = true;
            }
            else
            {
                if (roupa == roupaPadraoIdadeAcima)
                {
                    retorno = true;
                }
            }

            return retorno;

        }

        public void AtualizaCriancas()
        {
            var criancas = ObterTodos().ToList();
            foreach (var crianca in criancas)
            {
                AtualizaCrianca(crianca, true);
            }
        }

        public Crianca AtualizaCrianca(Crianca crianca, bool gravar = true)
        {
            var valCrianca = ValidaCrianca(
                new CriancaValue
                {
                    DataNascimento = crianca.DataNascimento, 
                    Sexo = crianca.Sexo, 
                    NescessidadeEspecial = crianca.NecessidadeEspecial ,
                    CadastroNovo = false
                }
                );
            crianca.Idade = valCrianca.Idade;
            crianca.IdadeNominal = valCrianca.IdadeNominal;
            crianca.IdadeNominalReduzida = valCrianca.IdadeNominalReduzida;
            crianca.MedidaIdade = valCrianca.MedidaIdade;
            crianca.MoralCrista = valCrianca.MoralCrista;

            if (crianca.DocumentoOk)
            {
                crianca.Status = valCrianca.Status;
                crianca.Consistente = valCrianca.Consistente;
                crianca.Sacolinha = valCrianca.Sacolinha;
            }
            if (crianca.CriancaMaiorMoralCrista())
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaMaiorLiberadaMoralCrista.Int());
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
                crianca.MoralCrista = true;
            }
            else
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaSemDocumentacao.Int());
                crianca.Consistente = false;
                crianca.Sacolinha = false;
            }

            if(gravar)
            {
                Atualizar(crianca);
            }

            return crianca;
        }

        public Dictionary<string, string> ObterVestimentaPadrao(int idade, string medidaIdade, string sexo, bool isCriancaGrande = false)
        {
            var calcadoPadrao = repCalcado.ObterPorSexoIdade(sexo, idade, medidaIdade).ToString();
            var roupaPadrao = repRoupa.ObterPorIdade(idade, medidaIdade);

            var dicReturn = new Dictionary<string, string>
            {
                {"calcado", calcadoPadrao}, 
                {"roupa", isCriancaGrande ? roupaPadrao.RoupaGrande : roupaPadrao.Roupa}
            };

            return dicReturn;

        }

        public IEnumerable<CriancaVestimenta> ObterDadosCriancaVestimentas(int familia)
        {
            var criancas = repCrianca.ObterDadosCriancaVestimentas(familia).ToList();

            criancas.ForEach(cr => cr.CalcadoPadrao = repCalcado.ObterPorSexoIdade(cr.Sexo, cr.Idade, cr.MedidaIdade));
            criancas.ForEach(cr => cr.RoupaPadrao = repRoupa.ObterPorIdade(cr.Idade, cr.MedidaIdade, cr.CriancaGrande));

            return criancas;
        }

        public Crianca ValidaCrianca(CriancaValue criancaValue)
        {
            var crianca = new Crianca
            {
                DataNascimento = criancaValue.DataNascimento,
                Sexo = criancaValue.Sexo,
                NecessidadeEspecial = criancaValue.NescessidadeEspecial,
                CriancaGrande = criancaValue.CriancaGrande
            };
            crianca.CalculaIdade();
            crianca.Kit = repKit.ObterKitPorIdade(crianca.Idade, crianca.Sexo, crianca.NecessidadeEspecial);

            if (criancaValue.CadastroNovo)
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CadastroNovo.Int());
                AjustaRoupaseCalcado(ref crianca);
            }

            if ((crianca.VerifyCalcado()) || (crianca.VerifyCalcado()))
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaSemRoupaCalcado.Int());
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
            }
            else
            {
                if (crianca.IdadePermitida())
                {
                    crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaMaior.Int());
                    crianca.Sacolinha = crianca.Status.PermiteSacola;
                    crianca.Consistente = crianca.Status.PermiteSacola;
                }
            }
            return crianca;
        }

        private void AjustaRoupaseCalcado(ref Crianca crianca)
        {
            var obterRoupa = repRoupa.ObterPorIdade(crianca.Idade, crianca.MedidaIdade);
            crianca.Calcado = repCalcado.ObterPorSexoIdade(crianca.Sexo, crianca.Idade, crianca.MedidaIdade);
            crianca.Roupa = obterRoupa.Roupa;

            if (crianca.CriancaGrande)
            {
                crianca.Roupa = obterRoupa.RoupaGrande;
            }

        }

    }
}