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
    public class FeriadoServiceApp :  IFeriadoServiceApp
    {
       
        private readonly IFeriadoService _service;

        public FeriadoServiceApp(IFeriadoService feriadoService)
        {
            _service = feriadoService;
        }

        public ValidationResult Gravar(FeriadoViewModel feriado)
        {
            var feriadoSalvar = Mapper.Map<Feriado>(feriado);
            return _service.Gravar(feriadoSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public FeriadoViewModel ObterPorId(int id)
        {
            var feriado = _service.ObterPorId(id);
            return Mapper.Map<FeriadoViewModel>(feriado);
        }

        public IEnumerable<FeriadoViewModel> ObterTodos()
        {
            var feriado = _service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<FeriadoViewModel>>(feriado);
            return retorno;
        }

        public IEnumerable<FeriadoViewModel> Filtrar(string nome)
        {
            var feriado = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<FeriadoViewModel>>(feriado);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
