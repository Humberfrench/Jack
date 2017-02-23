using AutoMapper;
using Jack.Application.AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class SacolaServiceApp : ISacolaServiceApp
    {

        private readonly ISacolaService service;
        private readonly IMapper mapper;

        public SacolaServiceApp(ISacolaService sacolaService)
        {
            service = sacolaService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public SacolaViewModel ObterPorId(int id)
        {
            var sacola = service.ObterPorId(id);
            return mapper.Map<SacolaViewModel>(sacola);
        }

        public IEnumerable<SacolaViewModel> ObterTodos()
        {
            var sacola = service.ObterTodos();
            return mapper.Map<IEnumerable<SacolaViewModel>>(sacola);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SacolaViewModel> ObterTodosPorNivel(int nivel, int liberado)
        {
            var sacola = service.ObterTodosPorNivel(nivel,liberado);
            return mapper.Map<IEnumerable<SacolaViewModel>>(sacola);
        }

        public IEnumerable<FamiliaViewModel> ObterFamiliasSacola()
        {
            var familias = service.ObterFamiliasSacola();
            return mapper.Map<IEnumerable<FamiliaViewModel>>(familias);
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
            return mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(int nivel = 0, int liberado = 2)
        {
            var familias = service.ObterSacolasLivres(nivel, liberado);
            return mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(bool? liberado, int ano, int nivel = 0, 
                                                               int familia = 0, string sexo = "", int kit = 0)
        {
            var familias = service.ObterSacolasLivres(liberado, ano,nivel,familia,sexo,kit );
            return mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public byte[] GerarQrCode(int width, int height, int crianca)
        {
            return service.GerarQrCode(width,height, crianca);
        }

        public byte[] GerarQrCode(int width, int height, CriancaViewModel crianca)
        {
            return service.GerarQrCode(width, height, mapper.Map<Sacola>(crianca));
        }

        public byte[] GerarQrCode(int width, int height, SacolaViewModel sacola)
        {
            return service.GerarQrCode(width, height, mapper.Map<Sacola>(sacola));
        }

        public byte[] GerarQrCodeSacola(int width, int height, int sacola)
        {
            return service.GerarQrCodeSacola(width, height, sacola);
        }


        public IEnumerable<SacolaValueViewModel> ObterSacolaParaImpressao(string sacolasNumero)
        {
            var sacola = service.ObterSacolaParaImpressao(sacolasNumero);
            return mapper.Map<IEnumerable<SacolaValueViewModel>>(sacola);
        }


        public List<SacolaViewModel> ProcessarSacolas(int ano)
        {

            var retorno = service.ProcessarSacolas(ano);

            var retornoViewModel = mapper.Map<List<SacolaViewModel>>(retorno);

            return retornoViewModel;
        }

        public List<SacolaViewModel> ProcessarSacolas(int ano, bool todas)
        {

            var retorno = service.ProcessarSacolas(ano);

            var retornoViewModel = mapper.Map<List<SacolaViewModel>>(retorno);

            return retornoViewModel;

        }

        public List<FamiliaViewModel> ProcessarSacolasEObterFamilias(int ano, bool todas)
        {
            var familias = service.ProcessarSacolasEObterFamilias(ano, todas);
            return mapper.Map<List<FamiliaViewModel>>(familias);

        }
        public List<FamiliaViewModel> ProcessarSacolasEObterFamilias(int ano)
        {
            var familias = service.ProcessarSacolasEObterFamilias(ano);
            return mapper.Map<List<FamiliaViewModel>>(familias);

        }

        public void ValidarCrianca(CriancaViewModel crianca)
        {
            var criancaDado = mapper.Map<Crianca>(crianca);
            service.ValidarCrianca(criancaDado);
        }
    }
}
