using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using System;
using System.Collections.Generic;
using Jack.Application.AutoMapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Application
{
    public class KitServiceApp :  IKitServiceApp
    {

        private readonly IKitService _service;
        private readonly IMapper mapper;

        public KitServiceApp(IKitService kitService)
        {
            _service = kitService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(KitViewModel kit)
        {
            var kitSalvar = mapper.Map<Kit>(kit);
            return _service.Gravar(kitSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public KitViewModel ObterPorId(int id)
        {
            var kit = _service.ObterPorId(id);
            return mapper.Map<KitViewModel>(kit);
        }

        public IEnumerable<KitViewModel> ObterTodos()
        {
            var kit = _service.ObterTodos();
            return mapper.Map<IEnumerable<KitViewModel>>(kit);
        }

        public IEnumerable<KitViewModel> Filtrar(string nome)
        {
            var kit = _service.Filtrar(nome);
            return mapper.Map<IEnumerable<KitViewModel>>(kit);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
