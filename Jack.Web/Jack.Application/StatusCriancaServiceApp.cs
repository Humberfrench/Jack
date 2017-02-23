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
    public class StatusCriancaServiceApp :  IStatusCriancaServiceApp
    {

        private readonly IStatusCriancaService _service;
        private readonly IMapper mapper;

        public StatusCriancaServiceApp(IStatusCriancaService statusService)
        {
            _service = statusService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(StatusCriancaViewModel status)
        {
            var statusSalvar = mapper.Map<StatusCrianca>(status);
            return _service.Gravar(statusSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public StatusCriancaViewModel ObterPorId(int id)
        {
            var status = _service.ObterPorId(id);
            return mapper.Map<StatusCriancaViewModel>(status);
        }

        public IEnumerable<StatusCriancaViewModel> ObterTodos()
        {
            var status = _service.ObterTodos();
            return mapper.Map<IEnumerable<StatusCriancaViewModel>>(status);
        }

        public IEnumerable<StatusCriancaViewModel> Filtrar(string nome)
        {
            var status = _service.Filtrar(nome);
            return mapper.Map<IEnumerable<StatusCriancaViewModel>>(status);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
