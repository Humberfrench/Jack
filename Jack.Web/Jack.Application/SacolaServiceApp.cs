using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using System;
using System.Collections.Generic;
using Jack.Application.AutoMapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Application
{
    public class SacolaServiceApp : ISacolaServiceApp
    {

        private readonly ISacolaService _service;
        private readonly IMapper mapper;

        public SacolaServiceApp(ISacolaService sacolaService)
        {
            _service = sacolaService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public SacolaViewModel ObterPorId(int id)
        {
            var sacola = _service.ObterPorId(id);
            return mapper.Map<SacolaViewModel>(sacola);
        }

        public IEnumerable<SacolaViewModel> ObterTodos()
        {
            var sacola = _service.ObterTodos();
            return mapper.Map<IEnumerable<SacolaViewModel>>(sacola);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SacolaViewModel> ObterTodosPorNivel(int nivel, int liberado)
        {
            var sacola = _service.ObterTodosPorNivel(nivel,liberado);
            return mapper.Map<IEnumerable<SacolaViewModel>>(sacola);
        }

        public IEnumerable<FamiliaViewModel> ObterFamiliasSacola()
        {
            var familias = _service.ObterFamiliasSacola();
            return mapper.Map<IEnumerable<FamiliaViewModel>>(familias);
        }

        public ValidationResult AddCrianca(int crianca)
        {
            return _service.AddCrianca(crianca);
        }

        public ValidationResult Liberar(int id)
        {
            return _service.Liberar(id);
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(int ano, bool? liberado)
        {
            var familias = _service.ObterSacolasLivres(ano, liberado);
            return mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(int nivel = 0, int liberado = 2)
        {
            var familias = _service.ObterSacolasLivres(nivel, liberado);
            return mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(bool? liberado, int ano, int nivel = 0, 
                                                               int familia = 0, string sexo = "", int kit = 0)
        {
            var familias = _service.ObterSacolasLivres(liberado, ano,nivel,familia,sexo,kit );
            return mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public byte[] GerarQrCode(int width, int height, int crianca)
        {
            return _service.GerarQrCode(width,height, crianca);
        }

        public byte[] GerarQrCode(int width, int height, CriancaViewModel crianca)
        {
            return _service.GerarQrCode(width, height, mapper.Map<Sacola>(crianca));
        }

        public byte[] GerarQrCode(int width, int height, SacolaViewModel sacola)
        {
            return _service.GerarQrCode(width, height, mapper.Map<Sacola>(sacola));
        }

        public byte[] GerarQrCodeSacola(int width, int height, int sacola)
        {
            return _service.GerarQrCodeSacola(width, height, sacola);
        }
    }
}
