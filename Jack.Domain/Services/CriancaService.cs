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
using System.Threading.Tasks;

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
        private readonly ILogRepository repLog;
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
                              ISacolaRepository repSacola,
                              ILogRepository repLog)
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
            this.repLog = repLog;
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
            Crianca crianca;
            if (item.Codigo == 0)
            {
                crianca = new Crianca();
                crianca.DataCriacao = DateTime.Now;
            }
            else
            {
                crianca = ObterPorId(item.Codigo);
            }

            crianca.Calcado = item.Calcado;
            crianca.CriancaGrande = item.CriancaGrande;
            crianca.Consistente = item.Consistente;
            crianca.DataAtualizacao = DateTime.Now;
            crianca.DataNascimento = item.DataNascimento;
            crianca.CalculaIdade();
            crianca.DocumentoOk = item.DocumentoOk;

            if (crianca.Kit.Codigo != item.Kit.Codigo)
            {
                crianca.Kit = repKit.ObterPorId(item.Kit.Codigo);
            }

            crianca.Roupa = item.Roupa;
            crianca.Calcado = item.Calcado;
            crianca.MoralCrista = item.MoralCrista;
            crianca.NecessidadeEspecial = item.NecessidadeEspecial;
            crianca.Nome = crianca.Nome;
            crianca.Sacolinha = item.Sacolinha;
            crianca.Sexo = item.Sexo;

            if (crianca.TipoParentesco.Codigo != item.TipoParentesco.Codigo)
            {
                crianca.TipoParentesco = repTipoParentesco.ObterPorId(item.TipoParentesco.Codigo);
            }

            AtualizaCrianca(crianca, false);

            if (crianca.Codigo == 0)
            {
                Adicionar(crianca);
            }
            else
            {
                Atualizar(crianca);
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

            //Parallel.ForEach(criancas, crianca =>
            //{
            //    AtualizaCrianca(crianca.Codigo, true);
            //});

            foreach (var crianca in criancas)
            {
                AtualizaCrianca(crianca.Codigo, true);
            }
            return validationResult;
        }

        public ValidationResult AtualizaCriancasMaiores()
        {
            IList<Crianca> criancas = ObterTodos().Where(c => c.Idade > 10 && c.MedidaIdade == "A" && !c.MoralCrista).ToList();

            foreach (var crianca in criancas)
            {
                crianca.CalculaIdade();
                Atualizar(crianca);
            }
            return validationResult;
        }

        public ValidationResult AtualizaCriancas()
        {
            return AtualizaCriancas(true);
        }

        public ValidationResult AtualizaCriancas(bool todas)
        {
            IList<Crianca> criancas;

            if (todas)
            {
                criancas = ObterTodos().ToList();

            }
            else
            {
                criancas = ObterTodos().Where(c => c.Idade <= Parametro.IdadeLimite && c.MedidaIdade == "A").ToList();
                ObterTodos()
                    .Where(c => c.Idade > Parametro.IdadeLimite && c.MedidaIdade == "A" && c.MoralCrista)
                    .ToList()
                    .ForEach(cr => criancas.Add(cr));
            }

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
            AtualizaCrianca(crianca, gravar);

            return validationResult;
        }

        public ValidationResult AtualizaCrianca(Crianca crianca, bool gravar)
        {
            var valCrianca = ValidaCrianca(
                new CriancaValue
                {
                    Codigo = crianca.Codigo,
                    Nome = crianca.Nome.GetFirstName(),
                    DataNascimento = crianca.DataNascimento,
                    Sexo = crianca.Sexo,
                    NescessidadeEspecial = crianca.NecessidadeEspecial,
                    CadastroNovo = false,
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
                AddLog(crianca.Codigo, EnumStatusCrianca.CriancaSemDocumentacao.Int(), "AtualizaCrianca", "Criança sem documentação");
                validationResult.AddWarning(string.Format("{0} - {1} - Criança Sem Documentação", crianca.Codigo, crianca.Nome.GetFirstName()));
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
            var criancas = repCrianca.ObterDadosCriancaVestimentas(familia).AsParallel().ToList();

            criancas.ForEach(cr => cr.CalcadoPadrao = repCalcado.ObterPorSexoIdade(cr.Sexo, cr.Idade, cr.MedidaIdade));
            criancas.ForEach(cr => cr.RoupaPadrao = repRoupa.ObterPorIdade(cr.Idade, cr.MedidaIdade, cr.CriancaGrande));

            return criancas;
        }

        public Crianca ValidaCrianca(CriancaValue criancaValue)
        {
            var crianca = new Crianca
            {
                Codigo = criancaValue.Codigo,
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
            if (!verifyCalcado && verifyRoupa)
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaSemCalcado.Int());
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
                AddLog(crianca.Codigo, EnumStatusCrianca.CriancaSemCalcado.Int(), "ValidarCalcadoERoupa", "Criança sem Calçado");
            }
            #endregion

            #region Verifica se tem roupa preenchida
            if (!verifyRoupa && verifyCalcado)
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaSemRoupa.Int());
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
                AddLog(crianca.Codigo, EnumStatusCrianca.CriancaSemRoupa.Int(), "ValidarCalcadoERoupa", "Criança sem Roupa");
            }
            #endregion
            #region Roupa e Calcado Não Preenchidos
            if ((!verifyCalcadoERoupa))
            {
                crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaSemRoupaCalcado.Int());
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
                AddLog(crianca.Codigo, EnumStatusCrianca.CriancaSemRoupaCalcado.Int(), "ValidarCalcadoERoupa", "Criança sem Calçado e Roupa");
                return;
            }
            #endregion

            #region Dados de Calçado e Roupa

            #region Idade Permitida
            if (!crianca.IdadePermitida())
            {
                //moral crista - temp para ajustar os dados
                if (crianca.CriancaMaiorMoralCrista())
                {
                    if (crianca.Idade > Parametro.LimiteIdadeMoralCrista)
                    {
                        crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaMaiorNaoLiberadaMoralCrista.Int());
                        AddLog(crianca.Codigo, EnumStatusCrianca.CriancaMaiorNaoLiberadaMoralCrista.Int(), "ValidarCalcadoERoupa", "Criança com idade não permitida, ex-aluno Moral Cristã");
                    }
                    else
                    {
                        crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaMaiorLiberadaMoralCrista.Int());
                    }
                }
                else
                {                   
                    crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.CriancaMaior.Int());
                    AddLog(crianca.Codigo, EnumStatusCrianca.CriancaMaior.Int(), "ValidarCalcadoERoupa", "Criança com idade não permitida");
               }
                crianca.Sacolinha = crianca.Status.PermiteSacola;
                crianca.Consistente = crianca.Status.PermiteSacola;
                return;
            }
            #endregion


            #region Consistencia do Calçado

            #region Informações para trabalho na consistencia de calçado
            var limiteCalcado = Parametro.CalcadoLimite;
            var calcadoService = new CalcadoService(repCalcado);
            var sexo = crianca.Sexo == "I" ? "M" : crianca.Sexo;
            var calcado = calcadoService.ObterCalcadoCrianca(crianca.Idade, crianca.MedidaIdade, sexo);
            var diferenca = (crianca.Calcado - calcado.Numero);
            var diferencaAbsoluta = Math.Abs((crianca.Calcado - calcado.Numero));
            #endregion
            if (Parametro.AjusteAutomaticoNoProcessamento)
            {
                // ajusto para tamanho menores apenas, para atualizar 
                // se for maior é por que a mãe informou maior. ai consisto
                //zero a diferença para que ele seja válido
                if (diferenca < 0)
                {
                    crianca.Calcado = calcado.Numero;
                    diferencaAbsoluta = 0;
                }
            }
            #region Analisa diferença
            if (diferencaAbsoluta > limiteCalcado)
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

            #region Ver de Novo um ano menor?

            if (!roupaOk)
            {
                idade = ObterIdadeParaPesquisaDeRoupas(crianca.Idade - 1, crianca.MedidaIdade, crianca.CriancaGrande);
                roupa = repRoupa.ObterPorIdade(idade, crianca.MedidaIdade);
                roupaOk = ConsisteRoupas(crianca.Roupa, roupa);
                if (roupaOk)
                {
                    //altero a roupa que ele mandou, por que pediu tamanho menor 
                    // que o permitido para a idade, assim automaticamente ajusto
                    // para o tamanho maior
                    // desta forma, se a mãe em um ano esquece, há o automatico ajuste para o maior.
                    idade = ObterIdadeParaPesquisaDeRoupas(crianca.Idade, crianca.MedidaIdade, crianca.CriancaGrande);
                    roupa = repRoupa.ObterPorIdade(idade, crianca.MedidaIdade);
                    crianca.Roupa = crianca.CriancaGrande ? roupa.RoupaGrande : roupa.Roupa;
                }
            }

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
                        AddLog(crianca.Codigo, EnumStatusCrianca.DiferencaGrandeCalcado.Int(), "ValidarCalcadoERoupa", "Criança com com diferença grande de Calçado");
                        //validationResult.AddWarning(string.Format("{0} - {1} - Criança com diferença grande de Calçado", crianca.Codigo, crianca.Nome.GetFirstName()));
                    }
                    else // => ver aqui
                    {
                        crianca.Status = repStatus.ObterPorId(EnumStatusCrianca.DiferencaGrandeRoupas.Int());
                        AddLog(crianca.Codigo, EnumStatusCrianca.DiferencaGrandeRoupas.Int(), "ValidarCalcadoERoupa", "Criança com com diferença grande de Roupas");
                        //validationResult.AddWarning(string.Format("{0} - {1} - Criança com diferença grande de Roupas", crianca.Codigo, crianca.Nome.GetFirstName()));
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
                    AddLog(crianca.Codigo, EnumStatusCrianca.DiferencaGrandeCalcado.Int(), "ValidarCalcadoERoupa", "Criança com com diferença grande de Calçado e Roupas");
                    validationResult.AddWarning(string.Format("{0} - {1} - Criança com diferença grande de Calçado e Roupas", crianca.Codigo, crianca.Nome.GetFirstName()));
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

        void AddLog(int codigo, int status, string processo, string mensagem)
        {
            var log = new Log
            {
                Codigo = codigo,
                StatusEntidade = status,
                Mensagem = mensagem,
                Processo = processo,
                Data = DateTime.Now,
                Entidade = "Crianca"
            };

            repLog.Adicionar(log);
        }


    }
}