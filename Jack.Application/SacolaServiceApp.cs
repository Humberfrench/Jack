using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class SacolaServiceApp : AppServiceBase, ISacolaServiceApp
    {

        private readonly ISacolaService service;

        public SacolaServiceApp(ISacolaService sacolaService)
        {
            service = sacolaService;
        }

        public SacolaViewModel ObterPorId(int id)
        {
            var sacola = service.ObterPorId(id);
            return Mapper.Map<SacolaViewModel>(sacola);
        }

        public IEnumerable<SacolaViewModel> ObterTodos()
        {
            var sacola = service.ObterTodos();
            return Mapper.Map<IEnumerable<SacolaViewModel>>(sacola);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SacolaViewModel> ObterTodosPorNivel(int nivel, int liberado)
        {
            var sacola = service.ObterTodosPorNivel(nivel, liberado);
            return Mapper.Map<IEnumerable<SacolaViewModel>>(sacola);
        }

        public IEnumerable<FamiliaViewModel> ObterFamiliasSacola()
        {
            var familias = service.ObterFamiliasSacola();
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familias);
        }

        public ValidationResult AddCrianca(int crianca)
        {
            return service.AddCrianca(crianca);
        }

        public ValidationResult Liberar(int id)
        {
            return service.Liberar(id);
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(int ano, bool? liberado)
        {
            var familias = service.ObterSacolasLivres(ano, liberado);
            return Mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(int nivel = 0, int liberado = 2)
        {
            var familias = service.ObterSacolasLivres(nivel, liberado);
            return Mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(bool? liberado, int ano, int nivel = 0,
                                                               int familia = 0, string sexo = "", int kit = 0)
        {
            var familias = service.ObterSacolasLivres(liberado, ano, nivel, familia, sexo, kit);
            return Mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public byte[] GerarQrCode(int width, int height, int crianca)
        {
            return service.GerarQrCode(width, height, crianca);
        }

        public byte[] GerarQrCode(int width, int height, CriancaViewModel crianca)
        {
            return service.GerarQrCode(width, height, Mapper.Map<Sacola>(crianca));
        }

        public byte[] GerarQrCode(int width, int height, SacolaViewModel sacola)
        {
            return service.GerarQrCode(width, height, Mapper.Map<Sacola>(sacola));
        }

        public byte[] GerarQrCodeSacola(int width, int height, int sacola)
        {
            return service.GerarQrCodeSacola(width, height, sacola);
        }


        public IEnumerable<SacolaValueViewModel> ObterSacolaParaImpressao(string sacolasNumero, int ano)
        {
            var sacola = service.ObterSacolaParaImpressao(sacolasNumero, ano);
            return Mapper.Map<IEnumerable<SacolaValueViewModel>>(sacola);
        }


        public List<SacolaViewModel> ProcessarSacolas(int ano)
        {

            var retorno = service.ProcessarSacolas(ano);

            var retornoViewModel = Mapper.Map<List<SacolaViewModel>>(retorno);

            return retornoViewModel;
        }

        public List<SacolaViewModel> ProcessarSacolas(int ano, bool todas)
        {

            var retorno = service.ProcessarSacolas(ano);

            var retornoViewModel = Mapper.Map<List<SacolaViewModel>>(retorno);

            return retornoViewModel;

        }

        public List<FamiliaViewModel> ProcessarSacolasEObterFamilias(int ano, bool todas)
        {
            var familias = service.ProcessarSacolasEObterFamilias(ano, todas);
            return Mapper.Map<List<FamiliaViewModel>>(familias);

        }
        public List<FamiliaViewModel> ProcessarSacolasEObterFamilias(int ano)
        {
            var familias = service.ProcessarSacolasEObterFamilias(ano);
            return Mapper.Map<List<FamiliaViewModel>>(familias);

        }

        public void ValidarCrianca(CriancaViewModel crianca)
        {
            var criancaDado = Mapper.Map<Crianca>(crianca);
            service.ValidarCrianca(criancaDado);
        }

        public IList<SacolaViewModel> PesquisarSacolas(int ano, int familia, int kit, int nivel)
        {
            var familias = service.PesquisarSacolas(ano, familia, kit, nivel);
            return Mapper.Map<List<SacolaViewModel>>(familias);
        }

        public IList<SacolaViewModel> PesquisarSacolas(int kit, int nivel)
        {
            var familias = service.PesquisarSacolas(kit, nivel);
            return Mapper.Map<List<SacolaViewModel>>(familias);
        }

        public IList<SacolaViewModel> PesquisarSacolas(int familia)
        {
            var familias = service.PesquisarSacolas(familia);
            return Mapper.Map<List<SacolaViewModel>>(familias);
        }

        public IList<FamiliaViewModel> ObterFamilias(int nivel)
        {
            var familias = service.ObterFamilias(nivel);
            return Mapper.Map<List<FamiliaViewModel>>(familias);
        }

        public ValidationResult AddCrianca(CriancaViewModel crianca)
        {
            var criancaDado = Mapper.Map<Crianca>(crianca);
            return service.AddCrianca(criancaDado);
        }

        public ValidationResult AddFamilia(int familia)
        {
            return service.AddFamilia(familia);
        }

        public IList<FamiliaViewModel> ObterFamiliasDisponiveis()
        {
            var familias = service.ObterFamiliasDisponiveis();
            return Mapper.Map<List<FamiliaViewModel>>(familias);
        }
    }
}
