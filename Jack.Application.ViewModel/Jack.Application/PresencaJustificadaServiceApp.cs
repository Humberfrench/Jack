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
    public class PresencaJustificadaServiceApp :  IPresencaJustificadaServiceApp
    {

        private readonly IPresencaJustificadaService _service;

        public PresencaJustificadaServiceApp(IPresencaJustificadaService presencaJustificadaService)
        {
            _service = presencaJustificadaService;
        }

        public ValidationResult Gravar(PresencaJustificadaViewModel presencaJustificada)
        {
            var presencaJustificadaSalvar = Mapper.Map<PresencaJustificada>(presencaJustificada);
            return _service.Gravar(presencaJustificadaSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public PresencaJustificadaViewModel ObterPorId(int id)
        {
            var presencaJustificada = _service.ObterPorId(id);
            return Mapper.Map<PresencaJustificadaViewModel>(presencaJustificada);
        }

        public IEnumerable<PresencaJustificadaViewModel> ObterTodos()
        {
            var presencaJustificada = _service.ObterTodos();
            return Mapper.Map<IEnumerable<PresencaJustificadaViewModel>>(presencaJustificada);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
