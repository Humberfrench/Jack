using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using System;
using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Application
{
    public class SacolaServiceApp : ISacolaServiceApp
    {

        private readonly ISacolaService _service;

        public SacolaServiceApp(ISacolaService sacolaService)
        {
            _service = sacolaService;
        }

        public SacolaViewModel ObterPorId(int id)
        {
            var sacola = _service.ObterPorId(id);
            return Mapper.Map<SacolaViewModel>(sacola);
        }

        public IEnumerable<SacolaViewModel> ObterTodos()
        {
            var sacola = _service.ObterTodos();
            return Mapper.Map<IEnumerable<SacolaViewModel>>(sacola);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SacolaViewModel> ObterTodosPorNivel(int nivel, int liberado)
        {
            var sacola = _service.ObterTodosPorNivel(nivel,liberado);
            return Mapper.Map<IEnumerable<SacolaViewModel>>(sacola);
        }

        public IEnumerable<FamiliaViewModel> ObterFamiliasSacola()
        {
            var familias = _service.ObterFamiliasSacola();
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familias);
        }

        public ValidationResult AddCrianca(int crianca)
        {
            return _service.AddCrianca(crianca);
        }

        public ValidationResult Liberar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(int ano, bool? liberado)
        {
            var familias = _service.ObterSacolasLivres(ano, liberado);
            return Mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(int nivel = 0, int liberado = 2)
        {
            var familias = _service.ObterSacolasLivres(nivel, liberado);
            return Mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }

        public IEnumerable<SacolaViewModel> ObterSacolasLivres(bool? liberado, int ano, int nivel = 0, 
                                                               int familia = 0, string sexo = "", int kit = 0)
        {
            var familias = _service.ObterSacolasLivres(liberado, ano,nivel,familia,sexo,kit );
            return Mapper.Map<IEnumerable<SacolaViewModel>>(familias);
        }
    }
}
