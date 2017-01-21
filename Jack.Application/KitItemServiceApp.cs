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
    public class KitItemServiceApp :  IKitItemServiceApp
    {

        private readonly IKitItemService _service;

        public KitItemServiceApp(IKitItemService kitItemService)
        {
            _service = kitItemService;
        }

        public ValidationResult Gravar(KitItemViewModel kitItem)
        {
            var kitItemSalvar = Mapper.Map<KitItem>(kitItem);
            return _service.Gravar(kitItemSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public KitItemViewModel ObterPorId(int id)
        {
            var kitItem = _service.ObterPorId(id);
            return Mapper.Map<KitItemViewModel>(kitItem);
        }

        public IEnumerable<KitItemViewModel> ObterTodos()
        {
            var kitItem = _service.ObterTodos();
            return Mapper.Map<IEnumerable<KitItemViewModel>>(kitItem);
        }

        public IEnumerable<KitItemViewModel> ObterTodos(int id)
        {
            var kitItem = _service.ObterTodos(id);
            return Mapper.Map<IEnumerable<KitItemViewModel>>(kitItem);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
