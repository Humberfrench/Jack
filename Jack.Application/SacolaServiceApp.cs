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

    }
}
