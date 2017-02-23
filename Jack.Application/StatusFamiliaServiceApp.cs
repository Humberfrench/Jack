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
    public class StatusFamiliaServiceApp : IStatusFamiliaServiceApp
    {

        private readonly IStatusFamiliaService _service;
        private readonly IMapper mapper;
        public StatusFamiliaServiceApp(IStatusFamiliaService statusService)
        {
            _service = statusService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(StatusFamiliaViewModel status)
        {
            var statusSalvar = mapper.Map<StatusFamilia>(status);
            return _service.Gravar(statusSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public StatusFamiliaViewModel ObterPorId(int id)
        {
            var status = _service.ObterPorId(id);
            return mapper.Map<StatusFamiliaViewModel>(status);
        }

        public IEnumerable<StatusFamiliaViewModel> ObterTodos()
        {
            var status = _service.ObterTodos();
            return mapper.Map<IEnumerable<StatusFamiliaViewModel>>(status);
        }

        public IEnumerable<StatusFamiliaViewModel> Filtrar(string nome)
        {
            var status = _service.Filtrar(nome);
            return mapper.Map<IEnumerable<StatusFamiliaViewModel>>(status);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
