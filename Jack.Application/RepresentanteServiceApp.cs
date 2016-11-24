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
    public class RepresentanteServiceApp :  IRepresentanteServiceApp
    {

        private readonly IRepresentanteService _service;

        public RepresentanteServiceApp(IRepresentanteService representanteService)
        {
            _service = representanteService;
        }

        public ValidationResult Gravar(RepresentanteViewModel representante)
        {
            var representanteSalvar = Mapper.Map<Representante>(representante);
            return _service.Gravar(representanteSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public RepresentanteViewModel ObterPorId(int id)
        {
            var representante = _service.ObterPorId(id);
            return Mapper.Map<RepresentanteViewModel>(representante);
        }

        public IEnumerable<RepresentanteViewModel> ObterTodos()
        {
            var representante = _service.ObterTodos();
            return Mapper.Map<IEnumerable<RepresentanteViewModel>>(representante);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
