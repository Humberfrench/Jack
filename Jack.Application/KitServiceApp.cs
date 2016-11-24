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
    public class KitServiceApp :  IKitServiceApp
    {

        private readonly IKitService _service;

        public KitServiceApp(IKitService KitService)
        {
            _service = KitService;
        }

        public ValidationResult Gravar(KitViewModel Kit)
        {
            var KitSalvar = Mapper.Map<Kit>(Kit);
            return _service.Gravar(KitSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public KitViewModel ObterPorId(int id)
        {
            var Kit = _service.ObterPorId(id);
            return Mapper.Map<KitViewModel>(Kit);
        }

        public IEnumerable<KitViewModel> ObterTodos()
        {
            var Kit = _service.ObterTodos();
            return Mapper.Map<IEnumerable<KitViewModel>>(Kit);
        }

        public IEnumerable<KitViewModel> Filtrar(string nome)
        {
            var Kit = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<KitViewModel>>(Kit);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
