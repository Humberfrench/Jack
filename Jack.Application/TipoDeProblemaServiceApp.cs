using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class TipoDeProblemaServiceApp : AppServiceBase, ITipoDeProblemaServiceApp
    {
        //

        private readonly ITipoDeProblemaService _service;

        public TipoDeProblemaServiceApp(ITipoDeProblemaService TipoDeProblemaService)
        {
            _service = TipoDeProblemaService;
        }

        public ValidationResult Gravar(TipoDeProblemaViewModel TipoDeProblema)
        {
            var TipoDeProblemaSalvar = Mapper.Map<TipoDeProblema>(TipoDeProblema);
            return _service.Gravar(TipoDeProblemaSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public TipoDeProblemaViewModel ObterPorId(int id)
        {
            var TipoDeProblema = _service.ObterPorId(id);
            return Mapper.Map<TipoDeProblemaViewModel>(TipoDeProblema);
        }

        public IEnumerable<TipoDeProblemaViewModel> ObterTodos()
        {
            var TipoDeProblema = _service.ObterTodos();
            return Mapper.Map<IEnumerable<TipoDeProblemaViewModel>>(TipoDeProblema);
        }

        public IEnumerable<TipoDeProblemaViewModel> Filtrar(string nome)
        {
            var TipoDeProblema = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<TipoDeProblemaViewModel>>(TipoDeProblema);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}