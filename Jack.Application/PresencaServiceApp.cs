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
    public class PresencaServiceApp :  IPresencaServiceApp
    {

        private readonly IPresencaService _service;

        public PresencaServiceApp(IPresencaService presencaService)
        {
            _service = presencaService;
        }

        public ValidationResult Gravar(int reuniao, int familia)
        {
            return _service.Gravar(reuniao, familia);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public PresencaViewModel ObterPorId(int id)
        {
            var presenca = _service.ObterPorId(id);
            return Mapper.Map<PresencaViewModel>(presenca);
        }

        public IEnumerable<PresencaViewModel> ObterTodos()
        {
            var presenca = _service.ObterTodos();
            return Mapper.Map<IEnumerable<PresencaViewModel>>(presenca);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
