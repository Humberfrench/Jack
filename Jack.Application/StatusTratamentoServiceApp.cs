using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class StatusTratamentoServiceApp : AppServiceBase, IStatusTratamentoServiceApp
    {

        private readonly IStatusTratamentoService service;
        public StatusTratamentoServiceApp(IStatusTratamentoService statusService)
        {
            service = statusService;
        }

        public ValidationResult Gravar(StatusTratamentoViewModel status)
        {
            var statusSalvar = Mapper.Map<StatusTratamento>(status);
            return service.Gravar(statusSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return service.Excluir(id);
        }

        public StatusTratamentoViewModel ObterPorId(int id)
        {
            var status = service.ObterPorId(id);
            return Mapper.Map<StatusTratamentoViewModel>(status);
        }

        public IEnumerable<StatusTratamentoViewModel> ObterTodos()
        {
            var status = service.ObterTodos();
            return Mapper.Map<IEnumerable<StatusTratamentoViewModel>>(status);
        }

        public IEnumerable<StatusTratamentoViewModel> Filtrar(string nome)
        {
            var status = service.Filtrar(nome);
            return Mapper.Map<IEnumerable<StatusTratamentoViewModel>>(status);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
