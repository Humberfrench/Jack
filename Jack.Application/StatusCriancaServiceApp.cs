using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class StatusCriancaServiceApp : AppServiceBase, IStatusCriancaServiceApp
    {

        private readonly IStatusCriancaService _service;

        public StatusCriancaServiceApp(IStatusCriancaService statusService)
        {
            _service = statusService;
        }

        public ValidationResult Gravar(StatusCriancaViewModel status)
        {
            var statusSalvar = Mapper.Map<StatusCrianca>(status);
            return _service.Gravar(statusSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public StatusCriancaViewModel ObterPorId(int id)
        {
            var status = _service.ObterPorId(id);
            return Mapper.Map<StatusCriancaViewModel>(status);
        }

        public IEnumerable<StatusCriancaViewModel> ObterTodos()
        {
            var status = _service.ObterTodos();
            return Mapper.Map<IEnumerable<StatusCriancaViewModel>>(status);
        }

        public IEnumerable<StatusCriancaViewModel> Filtrar(string nome)
        {
            var status = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<StatusCriancaViewModel>>(status);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
