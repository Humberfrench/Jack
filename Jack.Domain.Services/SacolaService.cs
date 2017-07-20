using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using Jack.Extensions;
using Jack.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jack.Domain.Services
{
    public class SacolaService : ServiceBase<Sacola>, ISacolaService
    {

        private readonly ISacolaRepository repSacola;
        private readonly IFamiliaRepository repFamilia;
        private readonly INivelRepository repNivel;
        private readonly ICriancaRepository repCrianca;
        private readonly IRepresentanteRepository repRepresentante;
        private readonly ValidationResult validationResult = new ValidationResult();
        private readonly IKitRepository repKit;
        private readonly IColaboradorCriancaService servColaboradorCrianca;
        private readonly Parametro Parametro;
        private readonly ILogSacolasRepository repLogSacolas;

        //suporte sacola geração
        private readonly IStatusCriancaRepository repStatusCrianca;
        private readonly IStatusFamiliaRepository repStatusFamilia;
        private readonly ICalcadoRepository repCalcado;
        private readonly IRoupaRepository repRoupa;
        private readonly ITipoParentescoRepository repTipoParentesco;
        private readonly IReuniaoRepository repReuniao;
        private readonly IPresencaRepository repPresenca;
        private readonly ILogRepository repLog;
        private readonly IParametroRepository repParametros;

        public SacolaService(ISacolaRepository repSacola,
                             IFamiliaRepository repFamilia,
                             INivelRepository repNivel,
                             ICriancaRepository repCrianca,
                             IRepresentanteRepository repRepresentante,
                             IKitRepository repKit,
                             IColaboradorCriancaService servColaboradorCrianca,
                             IParametroRepository repParametros,
                             IStatusCriancaRepository repStatusCrianca,
                             IStatusFamiliaRepository repStatusFamilia,
                             ICalcadoRepository repCalcado,
                             IRoupaRepository repRoupa,
                             ITipoParentescoRepository repTipoParentesco,
                             IReuniaoRepository repReuniao,
                             IPresencaRepository repPresenca,
                             ILogRepository repLog,
                             ILogSacolasRepository repLogSacolas)
            : base(repSacola)
        {
            this.repSacola = repSacola;
            this.repFamilia = repFamilia;
            this.repNivel = repNivel;
            this.repCrianca = repCrianca;
            this.repRepresentante = repRepresentante;
            this.servColaboradorCrianca = servColaboradorCrianca;
            this.repKit = repKit;
            this.repParametros = repParametros;
            this.repStatusCrianca = repStatusCrianca;
            this.repStatusFamilia = repStatusFamilia;
            this.repCalcado = repCalcado;
            this.repRoupa = repRoupa;
            this.repTipoParentesco = repTipoParentesco;
            this.repReuniao = repReuniao;
            this.repPresenca = repPresenca;
            this.repLog = repLog;
            this.repLogSacolas = repLogSacolas;
            Parametro = repParametros.Obter();
        }

        public IEnumerable<Sacola> ObterTodosPorNivel(int nivel, int liberado)
        {
            List<Sacola> sacolas;

            if (liberado == 1)
            {
                sacolas = ObterTodos().Where(s => s.Nivel.Codigo == nivel && s.Liberado).ToList();
            }
            else if (liberado == 2)
            {
                sacolas = ObterTodos().Where(s => s.Nivel.Codigo == nivel && s.Liberado == false).ToList();
            }
            else
            {
                sacolas = ObterTodos().Where(s => s.Nivel.Codigo == nivel).ToList();
            }

            return sacolas.OrderBy(s => s.Familia.Codigo);

        }

        public IEnumerable<Familia> ObterFamiliasSacola()
        {
            var sacolas = ObterTodos();

            var familias = sacolas.GroupBy(s => s.Familia.Codigo)
                .Select(s => s.First())
                .Select(s => s.Familia);

            return familias;
        }

        public IEnumerable<Sacola> ObterSacolasLivres(int nivel = 0, int liberado = 2)
        {
            bool? isLiberado;
            if (liberado == 0)
            {
                isLiberado = true;
            }
            else if (liberado == 1)
            {
                isLiberado = true;
            }
            else
            {
                isLiberado = null;
            }
            if (nivel == 0)
            {
                return ObterSacolasLivres(DateTime.Now.Year, isLiberado);
            }
            else
            {
                return ObterSacolasLivres(isLiberado, DateTime.Now.Year, nivel);
            }
        }

        public IEnumerable<Sacola> ObterSacolasLivres(int ano, bool? liberado)
        {
            var criancasDoColaborador = servColaboradorCrianca.ObterTodos()
                                      .Where(cc => cc.Ano == ano).ToList()
                                      .Select(cc => cc.Crianca);
            //var criancasDoColaborador1 = servColaboradorCrianca.ObterTodos()
            //                          .Where(cc => cc.Ano == ano).ToList();

            var sacolas = ObterTodos().ToList();

            foreach (var crianca in criancasDoColaborador)
            {
                var codigo = crianca.Codigo;
                var sacola = sacolas.FirstOrDefault(s => s.Crianca.Codigo == codigo);
                sacolas.Remove(sacola);
            }

            if (liberado.HasValue)
            {
                sacolas = sacolas.Where(s => s.Liberado == liberado.Value).ToList();
            }

            return sacolas;
        }

        public IEnumerable<Sacola> ObterSacolasLivres(bool? liberado,
                                                      int ano,
                                                      int nivel = 0,
                                                      int familia = 0,
                                                      string sexo = "",
                                                      int kit = 0)
        {
            var sacolas = ObterSacolasLivres(ano, liberado);

            if (nivel != 0)
            {
                sacolas = sacolas.Where(s => s.Nivel.Codigo == nivel);
            }

            if (familia != 0)
            {
                sacolas = sacolas.Where(s => s.Familia.Codigo == familia);
            }

            if (sexo != "0")
            {
                sacolas = sacolas.Where(s => s.Sexo == sexo);
            }

            if (kit != 0)
            {
                sacolas = sacolas.Where(s => s.Kit.Codigo == kit);
            }

            if (liberado.HasValue)
            {
                sacolas = sacolas.Where(s => s.Liberado == liberado.Value).ToList();
            }

            return sacolas;
        }

        public ValidationResult AddCrianca(int crianca)
        {
            var criancaSacola = repCrianca.ObterPorId(crianca);
            if (criancaSacola == null)
            {
                validationResult.Add("Criança não encontrada");
                return validationResult;
            }
            //consistir a criança  
            ValidarCrianca(criancaSacola);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            var sacolas = ObterTodos().ToList();
            var sacolasFamilia = sacolas.Where(s => s.Familia.Codigo == criancaSacola.Familia.Codigo).ToList();
            var numeroSacolaFamilia = 0;

            if (sacolasFamilia.Any())
            {
                var sacolaFamilia = sacolasFamilia.First();
                numeroSacolaFamilia = sacolaFamilia.SacolaFamilia;
            }
            else
            {
                var ultimaSacola = sacolas.OrderByDescending(s => s.SacolaFamilia).FirstOrDefault();
                if (ultimaSacola != null)
                {
                    numeroSacolaFamilia = ultimaSacola.SacolaFamilia + 1;
                }

            }

            var existeCrianca = sacolasFamilia.FirstOrDefault(s => s.Crianca.Codigo == crianca);
            if (existeCrianca != null)
            {
                validationResult.Add("Já existe a Criança na sacola");
                return validationResult;
            }

            var representante = repRepresentante.ObterTodos().FirstOrDefault(f => f.FamiliaRepresentada.Codigo == criancaSacola.Familia.Codigo);
            var familiaRepresentante = representante == null ? criancaSacola.Familia : representante.FamiliaRepresentante;

            //atualizar a criança
            criancaSacola.Kit = repKit.ObterKitPorIdade(criancaSacola.Idade, criancaSacola.Sexo, criancaSacola.NecessidadeEspecial);

            var sacola = new Sacola
            {
                SacolaFamilia = numeroSacolaFamilia,
                Crianca = criancaSacola,
                Familia = criancaSacola.Familia,
                FamiliaRepresentante = familiaRepresentante,
                Kit = criancaSacola.Kit,
                Impressa = false,
                Nivel = criancaSacola.Familia.Nivel,
                Liberado = true,
                Sexo = criancaSacola.Sexo
            };

            Adicionar(sacola);

            return validationResult;
        }

        public void ValidarCrianca(Crianca crianca)
        {

            if (!crianca.IdadePermitida())
            {
                validationResult.Add("Criança Maior que 10 anos e não participante da Escolinha.");
            }

            if (!crianca.VerifyCalcado())
            {
                validationResult.Add("Criança com Calçado inválido.");
            }

            if (!crianca.VerifyRoupa())
            {
                validationResult.Add("Criança com Roupa inválida.");
            }

            if (!crianca.DocumentoOk)
            {
                validationResult.Add("Criança com Documento inválido.");
            }

        }

        public ValidationResult Liberar(int id)
        {
            var sacola = ObterPorId(id);
            if (sacola == null)
            {
                validationResult.Add("Sacola não encontrada");
                return validationResult;
            }
            sacola.Liberado = true;
            Atualizar(sacola);
            return validationResult;
        }

        public byte[] GerarQrCode(int width, int height, int crianca)
        {
            var dadoCrianca = repCrianca.ObterPorId(crianca);
            return GerarQrCode(width, height, dadoCrianca);
        }

        public byte[] GerarQrCodeSacola(int width, int height, int sacola)
        {
            var dadoSacola = repSacola.ObterPorId(sacola);
            return GerarQrCode(width, height, dadoSacola);
        }

        public byte[] GerarQrCode(int width, int height, Crianca crianca)
        {
            var qrCoder = new QrCoder();
            var dadoQrCode = FormataDadoCriancaQrCode(crianca);

            return qrCoder.GerarQrCode(width, height, dadoQrCode);

        }

        public byte[] GerarQrCode(int width, int height, Sacola sacola)
        {
            var qrCoder = new QrCoder();

            var crianca = sacola.Crianca;

            var dadoQrCodeCrianca = FormataDadoCriancaQrCode(crianca);

            var dadoQrCodeSacola = FormataDadoSacolaQrCode(sacola);

            var dadoQrCode = dadoQrCodeSacola + dadoQrCodeCrianca;

            return qrCoder.GerarQrCode(width, height, dadoQrCode);

        }

        string FormataDadoSacolaQrCode(Sacola sacola)
        {
            StringBuilder dadoQrCode = new StringBuilder();
            dadoQrCode.AppendFormat("Sacola Número: {0}", sacola.Codigo);
            dadoQrCode.AppendLine();
            dadoQrCode.AppendFormat("Família Número: {0}", sacola.SacolaFamilia);
            dadoQrCode.AppendLine();
            return dadoQrCode.ToString();
        }

        string FormataDadoCriancaQrCode(Crianca crianca)
        {
            StringBuilder dadoQrCode = new StringBuilder();

            dadoQrCode.AppendFormat("Criança: {0}", crianca.Nome);
            dadoQrCode.AppendLine();
            dadoQrCode.AppendFormat("Idade: {0}", crianca.IdadeNominal);
            dadoQrCode.AppendLine();
            dadoQrCode.AppendFormat("Sexo: {0}", crianca.Sexo.ToSexo());
            dadoQrCode.AppendLine();
            dadoQrCode.AppendFormat("Calçado: {0} - Roupa: {1}", crianca.Calcado, crianca.Roupa);
            dadoQrCode.AppendLine();
            dadoQrCode.AppendFormat("Itens");
            dadoQrCode.AppendLine();

            foreach (var kitItem in crianca.Kit.Items.OrderBy(ki => ki.Ordem))
            {
                var opcional = kitItem.TipoItem.Opcional ? "(Opcional)" : "";
                dadoQrCode.AppendFormat("{0} - {1} {2}", kitItem.Ordem, kitItem.TipoItem.Descricao, opcional);
                dadoQrCode.AppendLine();
            }

            return dadoQrCode.ToString();

        }

        public List<Sacola> ProcessarSacolas(int ano)
        {
            return ProcessarSacolas(ano, true);
        }

        public List<Sacola> ProcessarSacolas(int ano, bool todas)
        {
            #region passos
            //1 - processa dados das crianças
            //2 - processa dados de presenças de famílias
            //5 - Limpar a tabela.
            //3 - processa dados de famílias
            //4 - obtem famílias de nível 1 a 5
            //5 - le família a família, e pega as crianças válidas
            //Passos acima, no método abaixo
            #endregion

            var sacolaFamilia = 0;
            var sacolaGeral = 0;
            var familias = ProcessarSacolasEObterFamilias(ano, todas).OrderBy(f => f.Codigo); //order by codigo temp para tesye


            #region 6 - formando o registro da sacola e inserindo.
            var sacolas = new List<Sacola>();
            foreach (var familia in familias)
            {
                sacolaFamilia++;
                var representante = repRepresentante.ObterRepresentante(familia.Codigo) ?? familia;
                foreach (var crianca in familia.Criancas)
                {
                    sacolaGeral++;

                    var sacola = new Sacola
                    {
                        Codigo = sacolaGeral,
                        SacolaFamilia = sacolaFamilia,
                        Crianca = crianca,
                        Nivel = familia.Nivel,
                        Familia = familia,
                        FamiliaRepresentante = representante,
                        Impressa = false,
                        Liberado = familia.Nivel.Codigo == 1 ? true : false,
                        Kit = crianca.Kit,
                        Sexo = crianca.Sexo

                    };

                    repSacola.Adicionar(sacola);
                    AddLog(sacola.Familia.Codigo,
                           sacola.FamiliaRepresentante.Codigo,
                           sacola.Crianca.Codigo,
                           sacola.Kit.Codigo,
                           DateTime.Now.Year);
                    sacolas.Add(sacola);

                }
            }
            #endregion

            return sacolas;

        }

        public List<Familia> ProcessarSacolasEObterFamilias(int ano)
        {
            return ProcessarSacolasEObterFamilias(ano, true);
        }

        public List<Familia> ProcessarSacolasEObterFamilias(int ano, bool todas)
        {

            var retValidator = new ValidationResult();

            //passos
            #region 1 - processa dados das crianças
            using (var criancaService = new CriancaService(repCrianca, repFamilia,
                                                    repStatusCrianca, repKit,
                                                    repCalcado, repRoupa,
                                                    repParametros,
                                                    repTipoParentesco, repSacola,
                                                    repLog))
            {
                retValidator = criancaService.AtualizaCriancas(todas);
                retValidator.Erros.ToList().ForEach(e => validationResult.Add(e));
                #endregion

                #region 2 - processa dados de presenças de famílias

                using (var presencaService = new PresencaService(repPresenca, repFamilia, repRepresentante, repReuniao, repParametros))
                {
                    retValidator = presencaService.ProcessarPresencaGarantida();
                    retValidator.Erros.ToList().ForEach(e => validationResult.Add(e));

                    retValidator = presencaService.ProcessarPresencaRepresentantes(); // problema , comendo memoria
                    retValidator.Erros.ToList().ForEach(e => validationResult.Add(e));
                    #endregion

                    #region 3 - processa dados de famílias
                    using (var familiaService = new FamiliaService(repFamilia, repNivel,
                                                            repStatusFamilia, repStatusCrianca,
                                                            repReuniao, repPresenca,
                                                            repParametros, repLog))
                    {
                        familiaService.AtualizarFamilias();
                        #endregion

                        #region 4 - obtem famílias de nível 1 a 5
                        var familias = repFamilia.ObterTodos()
                                                 .Where(f => f.Nivel.Codigo <= 5
                                                        && f.Status.PermiteSacola
                                                        && !f.BlackListPasso2)
                                                 .OrderBy(n => n.Nivel.Codigo)
                                                 .ThenBy(f => f.Nome).ToList();
                        #endregion

                        #region 5 - le família a família, e pega as crianças válidas
                        foreach (var familia in familias)
                        {
                            var criancas = new List<Crianca>();
                            bool add;
                            foreach (var crianca in familia.Criancas)
                            {
                                add = true;
                                //remove todas com status inválido.
                                if (!crianca.ValidaPorStatus())
                                {
                                    add = false;
                                }

                                if (!crianca.VerifyCalcado())
                                {
                                    add = false;
                                }

                                if (!crianca.VerifyRoupa())
                                {
                                    add = false;
                                }

                                if (!crianca.IdadePermitida())
                                {
                                    add = false;
                                }
                                if (add)
                                {
                                    criancas.Add(crianca);
                                }
                            }
                            familia.Criancas.Clear();
                            criancas.ForEach(c => familia.Criancas.Add(c));
                        }

                        #endregion

                        return familias.ToList();
                    }
                }
            }

        }
        private void AddLog(int familia, int familiaRepresentante, int crianca, int kit, int ano)
        {
            var log = new LogSacolas
            {
                FamiliaRepresentante = familiaRepresentante,
                Familia = familia,
                Crianca = crianca,
                Kit = kit,
                Ano = ano
            };

            repLogSacolas.Adicionar(log);
        }

        public IList<Sacola> PesquisarSacolas(int ano, int familia, int kit, int nivel)
        {
            var sacola = ObterTodos().ToList();

            if (familia != 0)
            {
                sacola = sacola.Where(s => s.Familia.Codigo == familia).ToList();
            }

            if (kit != 0)
            {
                sacola = sacola.Where(s => s.Kit.Codigo == kit).ToList();
            }

            if (nivel != 0)
            {
                sacola = sacola.Where(s => s.Nivel.Codigo == nivel).ToList();
            }

            //deixando só os colaboradores do ano
            sacola.ForEach(s => s.Crianca.Colaboradores = s.Crianca.Colaboradores.Where(c => c.Ano == ano).ToList());

            return sacola;
        }

        public IList<Sacola> ObterSacolaParaImpressao(string sacolasNumero, int ano)
        {
            var sacola = ObterTodos().ToList();
            var sacolas = new List<Sacola>();
            var numeros = sacolasNumero.Split(',').ToList();

            //falta filtrar as sacolas de acordo com a string
            numeros.ForEach(num => 
                                sacolas.Add(sacola.FirstOrDefault(
                                    sac => sac.Codigo.ToString() == num)));

            //deixando só os colaboradores do ano
            sacola.ForEach(s => s.Crianca.Colaboradores = s.Crianca.Colaboradores.Where(c => c.Ano == ano).ToList());

            return sacola;
        }

    }
}