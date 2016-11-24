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
    public class FamiliaBlackListServiceApp :  IFamiliaBlackListServiceApp
    {
       
        private readonly IFamiliaBlackListService _service;
        //readonly IMapper Mapper;

        public FamiliaBlackListServiceApp(IFamiliaBlackListService FamiliaBlackListService)
        {
            _service = FamiliaBlackListService;
        }

        public ValidationResult Gravar(FamiliaBlackListViewModel FamiliaBlackList)
        {
            var FamiliaBlackListSalvar = Mapper.Map<FamiliaBlackList>(FamiliaBlackList);
            return _service.Gravar(FamiliaBlackListSalvar);
        }


        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public FamiliaBlackListViewModel ObterPorId(int id)
        {
            var FamiliaBlackList = _service.ObterPorId(id);
            return Mapper.Map<FamiliaBlackListViewModel>(FamiliaBlackList);
        }

        public IEnumerable<FamiliaBlackListViewModel> ObterTodos()
        {
            var FamiliaBlackList = _service.ObterTodos();
            return Mapper.Map<IEnumerable<FamiliaBlackListViewModel>>(FamiliaBlackList);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
