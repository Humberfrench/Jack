using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using Jack.Extensions;
using Jack.Library;

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

        public SacolaService(ISacolaRepository repSacola, 
                             IFamiliaRepository repFamilia,
                             INivelRepository repNivel,
                             ICriancaRepository repCrianca,
                             IRepresentanteRepository repRepresentante,
                             IKitRepository repKit,
                             IColaboradorCriancaService servColaboradorCrianca)
            : base(repSacola)
        {
            this.repSacola = repSacola;
            this.repFamilia = repFamilia;
            this.repNivel = repNivel;
            this.repCrianca = repCrianca;
            this.repRepresentante = repRepresentante;
            this.servColaboradorCrianca = servColaboradorCrianca;
            this.repKit = repKit;
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

            return sacolas.OrderBy( s => s.Familia.Codigo);

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
            if(liberado == 0)
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
            if(!validationResult.IsValid)
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
    }
}