using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class TratamentoServiceApp : AppServiceBase, ITratamentoServiceApp
    {

        private readonly ITratamentoService service;
        public TratamentoServiceApp(ITratamentoService service)
        {
            this.service = service;
        }

        public ValidationResult Gravar(TratamentoViewModel tratamento)
        {
            var salvarTratamento = Mapper.Map<Tratamento>(tratamento);
            return service.Gravar(salvarTratamento);
        }

        public ValidationResult Excluir(int id)
        {
            return service.Excluir(id);
        }

        public TratamentoViewModel ObterPorId(int id)
        {
            var tratamento = service.ObterPorId(id);
            return Mapper.Map<TratamentoViewModel>(tratamento);
        }

        public IEnumerable<TratamentoViewModel> ObterTodos()
        {
            var tratamentos = service.ObterTodos();
            return Mapper.Map<IEnumerable<TratamentoViewModel>>(tratamentos);
        }
        public IEnumerable<TratamentoViewModel> ObterTodos(int familiaId)
        {
            var tratamentos = service.ObterTodos(familiaId);
            return Mapper.Map<IEnumerable<TratamentoViewModel>>(tratamentos);
        }

        public IEnumerable<TratamentoViewModel> Filtrar(string nome)
        {
            var tratamento = service.Filtrar(nome);
            return Mapper.Map<IEnumerable<TratamentoViewModel>>(tratamento);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
