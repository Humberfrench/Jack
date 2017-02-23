using AutoMapper;
using Jack.Application.AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class RepresentanteServiceApp :  IRepresentanteServiceApp
    {

        private readonly IRepresentanteService _service;
        private readonly IMapper mapper;

        public RepresentanteServiceApp(IRepresentanteService representanteService)
        {
            _service = representanteService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(RepresentanteViewModel representante)
        {
            var representanteSalvar = mapper.Map<Representante>(representante);
            return _service.Gravar(representanteSalvar);
        }

        public ValidationResult Gravar(int familiaRepresentante, int familiaRepresentada, int tipoParentesco)
        {
            return _service.Gravar(familiaRepresentante, familiaRepresentada, tipoParentesco);
        }

        public ValidationResult Gravar(int codigo, int tipoParentesco, bool ativo)
        {
            return _service.Gravar(codigo, tipoParentesco, ativo);
        }

        public ValidationResult Ativar(int id)
        {
            return _service.Ativar(id);
        }

        public ValidationResult Desativar(int id)
        {
            return _service.Desativar(id);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public IEnumerable<FamiliaViewModel> ObterFamilias(int familia)
        {
            var familias = _service.ObterFamilias(familia);
            return mapper.Map<IEnumerable<FamiliaViewModel>>(familias);
        }

        public RepresentanteViewModel ObterPorId(int id)
        {
            var representante = _service.ObterPorId(id);
            return mapper.Map<RepresentanteViewModel>(representante);
        }

        public IEnumerable<RepresentanteViewModel> ObterTodos()
        {
            var representante = _service.ObterTodos();
            return mapper.Map<IEnumerable<RepresentanteViewModel>>(representante);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
