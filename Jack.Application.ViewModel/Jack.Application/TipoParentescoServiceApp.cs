using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class TipoParentescoServiceApp : AppServiceBase, ITipoParentescoServiceApp
    {

        private readonly ITipoParentescoService _service;

        public TipoParentescoServiceApp(ITipoParentescoService tipoParentescoService)
        {
            _service = tipoParentescoService;
        }

        public ValidationResult Gravar(TipoParentescoViewModel tipoParentesco)
        {
            var tipoParentescoSalvar = Mapper.Map<TipoParentesco>(tipoParentesco);
            return _service.Gravar(tipoParentescoSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public TipoParentescoViewModel ObterPorId(int id)
        {
            var tipoParentesco = _service.ObterPorId(id);
            return Mapper.Map<TipoParentescoViewModel>(tipoParentesco);
        }

        public IEnumerable<TipoParentescoViewModel> ObterTodos()
        {
            var tipoParentesco = _service.ObterTodos();
            return Mapper.Map<IEnumerable<TipoParentescoViewModel>>(tipoParentesco);
        }

        public IEnumerable<TipoParentescoViewModel> Filtrar(string nome)
        {
            var tipoParentesco = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<TipoParentescoViewModel>>(tipoParentesco);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
