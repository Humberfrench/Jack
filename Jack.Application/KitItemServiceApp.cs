﻿using AutoMapper;
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
    public class KitItemServiceApp :  IKitItemServiceApp
    {

        private readonly IKitItemService _service;
        private readonly IMapper mapper;

        public KitItemServiceApp(IKitItemService kitItemService)
        {
            _service = kitItemService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(KitItemViewModel kitItem)
        {
            var kitItemSalvar = mapper.Map<KitItem>(kitItem);
            return _service.Gravar(kitItemSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public KitItemViewModel ObterPorId(int id)
        {
            var kitItem = _service.ObterPorId(id);
            return mapper.Map<KitItemViewModel>(kitItem);
        }

        public IEnumerable<KitItemViewModel> ObterTodos()
        {
            var kitItem = _service.ObterTodos();
            return mapper.Map<IEnumerable<KitItemViewModel>>(kitItem);
        }

        public IEnumerable<KitItemViewModel> ObterTodos(int id)
        {
            var kitItem = _service.ObterTodos(id);
            return mapper.Map<IEnumerable<KitItemViewModel>>(kitItem);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
