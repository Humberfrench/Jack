using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class TipoItemServiceApp : AppServiceBase, ITipoItemServiceApp
    {

        private readonly ITipoItemService _service;

        public TipoItemServiceApp(ITipoItemService tipoItemService)
        {
            _service = tipoItemService;
        }

        public ValidationResult Gravar(TipoItemViewModel tipoItem)
        {
            var tipoItemSalvar = Mapper.Map<TipoItem>(tipoItem);
            return _service.Gravar(tipoItemSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public TipoItemViewModel ObterPorId(int id)
        {
            var tipoItem = _service.ObterPorId(id);
            return Mapper.Map<TipoItemViewModel>(tipoItem);
        }

        public IEnumerable<TipoItemViewModel> ObterTodos()
        {
            var tipoItem = _service.ObterTodos();
            return Mapper.Map<IEnumerable<TipoItemViewModel>>(tipoItem);
        }

        public IEnumerable<TipoItemViewModel> Filtrar(string nome)
        {
            var tipoItem = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<TipoItemViewModel>>(tipoItem);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
