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
    public class StatusServiceApp :  IStatusServiceApp
    {

        private readonly IStatusService _service;

        public StatusServiceApp(IStatusService statusService)
        {
            _service = statusService;
        }

        public ValidationResult Gravar(StatusViewModel status)
        {
            var statusSalvar = Mapper.Map<Status>(status);
            return _service.Gravar(statusSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public StatusViewModel ObterPorId(int id)
        {
            var status = _service.ObterPorId(id);
            return Mapper.Map<StatusViewModel>(status);
        }

        public IEnumerable<StatusViewModel> ObterTodos()
        {
            var status = _service.ObterTodos();
            return Mapper.Map<IEnumerable<StatusViewModel>>(status);
        }

        public IEnumerable<StatusViewModel> Filtrar(string nome)
        {
            var status = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<StatusViewModel>>(status);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
