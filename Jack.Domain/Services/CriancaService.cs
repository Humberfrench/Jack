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

    public class CriancaService : ServiceBase<Crianca>, ICriancaService
    {

        private readonly ICriancaRepository repCrianca;
        private readonly IStatusCriancaRepository repStatus;
        private readonly IKitRepository repKit;
        private readonly ICalcadoRepository repCalcado;
        private readonly IRoupaRepository repRoupa;
        private readonly IParametroRepository repParametros;

        private readonly ValidationResult validationResult = new ValidationResult();

        public CriancaService(ICriancaRepository repCrianca,
                              IStatusCriancaRepository repStatus,
                              IKitRepository repKit,
                              ICalcadoRepository repCalcado,
                              IRoupaRepository repRoupa,
                              IParametroRepository repParametros)
            : base(repCrianca)
        {
            this.repCrianca = repCrianca;
            this.repStatus = repStatus;
            this.repKit = repKit;
            this.repCalcado = repCalcado;
            this.repRoupa = repRoupa;
            this.repParametros = repParametros;
        }
        public IEnumerable<Crianca> ObterCriancas(int familia)
        {
            var registros = Pesquisar(p => p.Familia.Codigo == familia).ToList();
            return registros;
        }

        public ValidationResult Gravar(Crianca item)
        {
            if (item.Codigo == 0)
            {
                Adicionar(item);
            }
            else
            {
                Atualizar(item);
            }

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
            var roupaDado = repRoupa.ObterPorSexoIdade(sexo, idade, medidaIdade);
            var roupaDadoIdadeAcima = repRoupa.ObterPorSexoIdade(sexo, idade + 1, medidaIdade);

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
            var valCrianca = ValidaCrianca(crianca.DataNascimento, crianca.Sexo, crianca.NecessidadeEspecial);
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

        public Crianca ValidaCrianca(DateTime dataNasc, string sexo, bool cadastroNovo = false, bool necessidadeEspecial = false)
        {
            var crianca = new Crianca
            {
                DataNascimento = dataNasc,
                Sexo = sexo,
                NecessidadeEspecial = necessidadeEspecial
            };
            crianca.CalculaIdade();
            crianca.Kit = repKit.ObterKitPorIdade(crianca.Idade, crianca.Sexo, crianca.NecessidadeEspecial);

            if (cadastroNovo)
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
            var obterRoupa = repRoupa.ObterPorSexoIdade(crianca.Sexo, crianca.Idade, crianca.MedidaIdade);
            crianca.Calcado = repCalcado.ObterPorSexoIdade(crianca.Sexo, crianca.Idade, crianca.MedidaIdade);

            if (crianca.CriancaGrande)
            {
                crianca.Roupa = obterRoupa.Roupa;
            }
            else
            {
                crianca.Roupa = obterRoupa.RoupaGrande;
            }

        }

    }
}