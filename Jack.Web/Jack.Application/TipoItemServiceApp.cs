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
    public class TipoItemServiceApp :  ITipoItemServiceApp
    {

        private readonly ITipoItemService _service;
        private readonly IMapper mapper;

        public TipoItemServiceApp(ITipoItemService tipoItemService)
        {
            _service = tipoItemService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(TipoItemViewModel tipoItem)
        {
            var tipoItemSalvar = mapper.Map<TipoItem>(tipoItem);
            return _service.Gravar(tipoItemSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public TipoItemViewModel ObterPorId(int id)
        {
            var tipoItem = _service.ObterPorId(id);
            return mapper.Map<TipoItemViewModel>(tipoItem);
        }

        public IEnumerable<TipoItemViewModel> ObterTodos()
        {
            var tipoItem = _service.ObterTodos();
            return mapper.Map<IEnumerable<TipoItemViewModel>>(tipoItem);
        }

        public IEnumerable<TipoItemViewModel> Filtrar(string nome)
        {
            var tipoItem = _service.Filtrar(nome);
            return mapper.Map<IEnumerable<TipoItemViewModel>>(tipoItem);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
