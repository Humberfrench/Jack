using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class TratamentoTiposDeProblemaServiceApp : AppServiceBase, ITratamentoTiposDeProblemaServiceApp
    {

        private readonly ITratamentoTiposDeProblemaService service;
        public TratamentoTiposDeProblemaServiceApp(ITratamentoTiposDeProblemaService service)
        {
            this.service = service;
        }

        public ValidationResult Gravar(TratamentoTipoDeProblemaViewModel tratamento)
        {
            var salvarTratamento = Mapper.Map<TratamentoTipoDeProblema>(tratamento);
            return service.Gravar(salvarTratamento);
        }

        public ValidationResult Excluir(int id)
        {
            return service.Excluir(id);
        }

        public TratamentoTipoDeProblemaViewModel ObterPorId(int id)
        {
            var tratamento = service.ObterPorId(id);
            return Mapper.Map<TratamentoTipoDeProblemaViewModel>(tratamento);
        }

        public IEnumerable<TratamentoTipoDeProblemaViewModel> ObterTodos()
        {
            var tratamentos = service.ObterTodos();
            return Mapper.Map<IEnumerable<TratamentoTipoDeProblemaViewModel>>(tratamentos);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
