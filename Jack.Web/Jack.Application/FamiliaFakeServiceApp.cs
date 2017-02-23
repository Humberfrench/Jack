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
    public class FamiliaFakeServiceApp :  IFamiliaFakeServiceApp
    {

        private readonly IFamiliaFakeService _service;

        public FamiliaFakeServiceApp(IFamiliaFakeService FamiliaFakeService)
        {
            _service = FamiliaFakeService;
        }

        public ValidationResult Gravar(FamiliaFakeViewModel FamiliaFake)
        {
            var FamiliaFakeSalvar = Mapper.Map<FamiliaFake> (FamiliaFake);
            return _service.Gravar(FamiliaFakeSalvar);
        }

       public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public FamiliaFakeViewModel ObterPorId(int id)
        {
            var FamiliaFake = _service.ObterPorId(id);
            return Mapper.Map<FamiliaFakeViewModel>(FamiliaFake);
        }

        public IEnumerable<FamiliaFakeViewModel> ObterTodos()
        {
            var FamiliaFake = _service.ObterTodos();
            return Mapper.Map<IEnumerable<FamiliaFakeViewModel>>(FamiliaFake);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
