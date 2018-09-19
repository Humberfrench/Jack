using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class KitServiceApp : AppServiceBase, IKitServiceApp
    {

        private readonly IKitService _service;

        public KitServiceApp(IKitService kitService)
        {
            _service = kitService;
        }

        public ValidationResult Gravar(KitViewModel kit)
        {
            var kitSalvar = Mapper.Map<Kit>(kit);
            return _service.Gravar(kitSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public KitViewModel ObterPorId(int id)
        {
            var kit = _service.ObterPorId(id);
            return Mapper.Map<KitViewModel>(kit);
        }

        public IEnumerable<KitViewModel> ObterTodos()
        {
            var kit = _service.ObterTodos();
            return Mapper.Map<IEnumerable<KitViewModel>>(kit);
        }

        public IEnumerable<KitViewModel> Filtrar(string nome)
        {
            var kit = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<KitViewModel>>(kit);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
