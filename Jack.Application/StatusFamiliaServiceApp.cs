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
    public class StatusFamiliaServiceApp : IStatusFamiliaServiceApp
    {

        private readonly IStatusFamiliaService _service;

        public StatusFamiliaServiceApp(IStatusFamiliaService statusService)
        {
            _service = statusService;
        }

        public ValidationResult Gravar(StatusFamiliaViewModel status)
        {
            var statusSalvar = Mapper.Map<StatusFamilia>(status);
            return _service.Gravar(statusSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public StatusFamiliaViewModel ObterPorId(int id)
        {
            var status = _service.ObterPorId(id);
            return Mapper.Map<StatusFamiliaViewModel>(status);
        }

        public IEnumerable<StatusFamiliaViewModel> ObterTodos()
        {
            var status = _service.ObterTodos();
            return Mapper.Map<IEnumerable<StatusFamiliaViewModel>>(status);
        }

        public IEnumerable<StatusFamiliaViewModel> Filtrar(string nome)
        {
            var status = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<StatusFamiliaViewModel>>(status);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
