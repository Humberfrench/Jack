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
    public class RoupaServiceApp :  IRoupaServiceApp
    {

        private readonly IRoupaService _service;
        private readonly IMapper mapper;

        public RoupaServiceApp(IRoupaService roupaService)
        {
            _service = roupaService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }


        public RoupaViewModel ObterPorId(int id)
        {
            var roupa = _service.ObterPorId(id);
            return mapper.Map<RoupaViewModel>(roupa);
        }

        public IEnumerable<RoupaViewModel> ObterTodos()
        {
            var roupa = _service.ObterTodos();
            return mapper.Map<IEnumerable<RoupaViewModel>>(roupa);
        }

 public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
