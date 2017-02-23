using Jack.Domain.Entity;
using Jack.Domain.Enum;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;
using Jack.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly ITipoParentescoRepository repTipoParentesco;
        private readonly Parametro Parametro;


        private readonly ValidationResult validationResult = new ValidationResult();

        public CriancaService(ICriancaRepository repCrianca,
                              IFamiliaRepository repFamilia,
                              IStatusCriancaRepository repStatus,
                              IKitRepository repKit,
                              ICalcadoRepository repCalcado,
                              IRoupaRepository repRoupa,
                              IParametroRepository repParametros,
                              ITipoParentescoRepository repTipoParentesco,
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
            this.repTipoParentesco = repTipoParentesco;
            this.repSacola = repSacola;
            Parametro = repParametros.Obter();
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

        public ValidationResult GravarDados(int crianca, int calcado, string roupa, int tipoParentesco)
        {
            var item = repCrianca.ObterPorId(crianca);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }

            item.TipoParentesco = repTipoParentesco.ObterPorId(tipoParentesco);
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

        public ValidationResult AtualizaCriancas(int familiaId)
        {
            var familia = repFamilia.ObterPorId(familiaId);
            var criancas = familia.Criancas.ToList();

            foreach (var crianca in criancas)
            {
                AtualizaCrianca(crianca.Codigo, true);
            }
            return validationResult;
        }

        public ValidationResult AtualizaCriancas()
        {
            var criancas = ObterTodos().ToList();
            foreach (var crianca in criancas)
            {
                AtualizaCrianca(crianca.Codigo, true);
            }
            return validationResult;
        }

        public ValidationResult AtualizaCrianca(int id, bool gravar)
        {
            var crianca = ObterPorId(id);

            if (crianca == null)
            {
                validationResult.Add("Registro não encontrado");
                return validationResult;
            }

            var valCrianca = ValidaCrianca(
                new CriancaValue
                {
                    Nome = crianca.Nome.GetFirstName(),
                    DataNascimento = crianca.DataNascimento,
                    Sexo = crianca.Sexo,
                    NescessidadeEspecial = crianca.NecessidadeEspecial,
                    CadastroNovo = false ,
                    Calcado = crianca.Calcado,
                    Roupa = crianca.Roupa
                });

            crianca.Idade = valCrianca.Idade;
            crianca.IdadeNominal = valCrianca.IdadeNominal;
            crianca.IdadeNominalReduzida = valCrianca.IdadeNominalReduzida;
            crianca.MedidaIdade = valCrianca.MedidaIdade;
            crianca.MoralCrista = valCrianca.MoralCrista;
            crianca.Calcado = valCrianca.Calcado;
            crianca.Roupa = valCrianca.Roupa;
            crianca.Status = valCrianca.Status;

            if (crianca.DocumentoOk)
            {
                crianca.Status = valCrianca.Status;
                crianca.Consistente = valCrianca.Consistente;
                crianca.Sacolinha = valCrianca.Sacolinha;
            }
            else
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaSemDocumentacao.Int());
                crianca.Consistente = false;
                crianca.Sacolinha = false;
                validationResult.AddWarning(string.Format("{0} - Criança Sem Documentação", crianca.Nome.GetFirstName()));
            }

            if (gravar)
            {
                Atualizar(crianca);
            }

            return validationResult;
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
                Nome = criancaValue.Nome,
                DataNascimento = criancaValue.DataNascimento,
                Sexo = criancaValue.Sexo,
                NecessidadeEspecial = criancaValue.NescessidadeEspecial,
                CriancaGrande = criancaValue.CriancaGrande,
                Calcado = criancaValue.Calcado,
                Roupa = criancaValue.Roupa
            };

            crianca.CalculaIdade();
            crianca.Kit = repKit.ObterKitPorIdade(crianca.Idade, crianca.Sexo, crianca.NecessidadeEspecial);

            if (criancaValue.CadastroNovo)
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CadastroNovo.Int());
                AjustaRoupaseCalcado(ref crianca);
            }
            else
            {
                ValidarCalcadoERoupa(ref crianca);
            }

            return crianca;
        }

        private void ValidarCalcadoERoupa(ref Crianca crianca)
        {

            #region Carregar Dados Iniciais
            var verifyCalcado = crianca.VerifyCalcado();
            var verifyRoupa = crianca.VerifyRoupa();
            var verifyCalcadoERoupa = verifyCalcado && verifyRoupa;

            crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaSemRoupaCalcado.Int());
            crianca.Sacolinha = crianca.Status.PermiteSacola;
            crianca.Consistente = crianca.Status.PermiteSacola;
            #endregion

            #region Verifica se tem calçado preenchido
            if (!verifyCalcado)
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaSemCalcado.Int());
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
                validationResult.AddWarning(string.Format("{0} - Criança sem Calçado", crianca.Nome));
            }
            #endregion

            #region Verifica se tem roupa preenchida
            if (!verifyRoupa)
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaSemRoupa.Int());
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
                validationResult.AddWarning(string.Format("{0} - Criança sem Roupa", crianca.Nome));
            }
            #endregion

            #region Roupa e Calcado Não Preenchidos
            if ((!verifyCalcadoERoupa))
            {
                    crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaSemRoupaCalcado.Int());
                    crianca.Sacolinha = crianca.Status.PermiteSacola;
                    crianca.Consistente = crianca.Status.PermiteSacola;
                    validationResult.AddWarning(string.Format("{0} - Criança sem Calçado e Roupa", crianca.Nome));
                    return;
            }
            #endregion

            #region Dados de Calçado e Roupa

            #region Idade Permitida
            if (!crianca.IdadePermitida())
            {
                //moral crista - temp para ajustar os dados
                if (!crianca.CriancaMaiorMoralCrista())
                {
                    crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaMaiorLiberadaMoralCrista.Int());
                    crianca.Sacolinha = crianca.Status.PermiteSacola;
                    crianca.Consistente = crianca.Status.PermiteSacola;
                    validationResult.AddWarning(string.Format("{0} - Criança Maior e moral Cristã, não consistiu calçado", crianca.Nome));
                    return;
                }
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaMaior.Int());
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
                validationResult.AddWarning(string.Format("{0} - Criança com idade não permitida", crianca.Nome));
                return;
            }
            #endregion


            #region Consistencia do Calçado

            #region Informações para trabalho na consistencia de calçado
            var limiteCalcado = Parametro.CalcadoLimite;
            var calcadoService = new CalcadoService(repCalcado);
            var calcado = calcadoService.ObterCalcadoCrianca(crianca.Idade, crianca.MedidaIdade, crianca.Sexo);
            var diferenca = Math.Abs((crianca.Calcado - calcado.Numero));
            #endregion

            #region Analisa diferença
            if (diferenca > limiteCalcado)
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.DiferencaGrandeCalcado.Int());
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
            }
            #endregion

            #endregion

            #region Consistencia de Roupas

            #region Obter Informações
            //trabalhar diferença de roupas.
            var idade = ObterIdadeParaPesquisaDeRoupas(crianca.Idade, crianca.MedidaIdade, crianca.CriancaGrande);
            var roupa = repRoupa.ObterPorIdade(idade, crianca.MedidaIdade);
            var roupaPadrao = roupa.RoupaGrande; // guardo o valor padrão
            var roupaOk = ConsisteRoupas(crianca.Roupa, roupa);
            #endregion

            #region Tamanho Menor
            //não houve consenso para a idade. Verificarei para tamanho menor.
            if (!roupaOk)
            {
                // antes ver se é RN...
                if ((crianca.Idade != 0) &&
                    string.Compare(crianca.MedidaIdade, "M", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    roupa = repRoupa.ObterPorIdade(crianca.Idade - 1, crianca.MedidaIdade);
                    roupaOk = ConsisteRoupas(crianca.Roupa, roupa);
                    if (roupaOk)
                    {
                        //altero a roupa que ele mandou, por que pediu tamanho menor 
                        // que o permitido para a idade, assim automaticamente ajusto
                        // para o tamanho maior
                        // desta forma, se a mãe em um ano esquece, há o automatico ajuste para o maior.
                        crianca.Roupa = roupaPadrao;
                    }
                }
                else
                {
                    if (crianca.Status.Codigo == EnumStatusCrianca.DiferencaGrandeCalcado.Int())
                    {
                        crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.DiferencaGrandeCalcadoRoupas.Int());
                        validationResult.AddWarning(string.Format("{0} - Criança com diferença grande de Calçado", crianca.Nome));
                    }
                    else
                    {
                        crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.DiferencaGrandeRoupas.Int());
                        validationResult.AddWarning(string.Format("{0} - Criança com diferença grande de Roupas", crianca.Nome));
                    }
                    crianca.Sacolinha = crianca.Status.PermiteSacola;
                    crianca.Consistente = crianca.Status.PermiteSacola;
                    return;
                }
            }
            #endregion

            #region Tamanho Maior
            //não houve consenso para a idade menor. Verificarei para tamanho maior.
            if (!roupaOk)
            {
                if ((crianca.Idade == 11) &&
                    string.Compare(crianca.MedidaIdade, "M", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    roupa = repRoupa.ObterPorIdade(1, "A");
                    roupaOk = ConsisteRoupas(crianca.Roupa, roupa);
                }
                else
                {
                    roupa = repRoupa.ObterPorIdade(crianca.Idade + 1, crianca.MedidaIdade);
                    roupaOk = ConsisteRoupas(crianca.Roupa, roupa);
                }

            }
            #endregion

            #region Conclusões das Análises e Retorno Final
            if (!roupaOk)
            {
                if (crianca.Status.Codigo == EnumStatusCrianca.DiferencaGrandeCalcado.Int())
                {
                    crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.DiferencaGrandeCalcadoRoupas.Int());
                    validationResult.AddWarning(string.Format("{0} - Criança com diferença grande de Calçado e de Roupas", crianca.Nome));
                }
                else
                {
                    crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.DiferencaGrandeRoupas.Int());
                }
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
                return;
            }

            crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.DadosOk.Int());
            crianca.Sacolinha = crianca.Status.PermiteSacola;
            crianca.Consistente = crianca.Status.PermiteSacola;

            #endregion

            #endregion

            #endregion

        }

        private int ObterIdadeParaPesquisaDeRoupas(int idade, string medidaIdade, bool isGrande)
        {
            //até um ano, desconsiderar a idade
            if (string.Compare(medidaIdade, "M", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return idade;
            }
            if (isGrande)
            {
                idade++;
                return idade;
            }
            return idade;
        }

        private bool ConsisteRoupas(string criancaRoupa, RoupaValue roupa)
        {
            var roupaOk = string.Compare(criancaRoupa, roupa.Roupa, StringComparison.OrdinalIgnoreCase) == 0;

            //Se bateu, com o padrão normal, devolver true.
            if (roupaOk)
            {
                return true;
            }

            //tamanho maior
            roupaOk = string.Compare(criancaRoupa, roupa.RoupaGrande, StringComparison.OrdinalIgnoreCase) == 0;

            //Se bateu, com o padrão maior, devolver true.
            if (roupaOk)
            {
                return true;
            }

            return false;

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