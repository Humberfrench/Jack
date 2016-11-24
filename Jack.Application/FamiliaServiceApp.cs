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
    public class FamiliaServiceApp :  IFamiliaServiceApp
    {

        private readonly IFamiliaService _service;

        public FamiliaServiceApp(IFamiliaService familiaService)
        {
            _service = familiaService;
        }

        public ValidationResult Gravar(FamiliaViewModel familia)
        {
            var familiaSalvar = Mapper.Map<Familia>(familia);
            return _service.Gravar(familiaSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public FamiliaViewModel ObterPorId(int id)
        {
            var familia = _service.ObterPorId(id);
            return Mapper.Map<FamiliaViewModel>(familia);
        }

        public IEnumerable<FamiliaViewModel> ObterTodos()
        {
            var familia = _service.ObterTodos();
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public IEnumerable<FamiliaViewModel> Filtrar(string nome)
        {
            var familia = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
