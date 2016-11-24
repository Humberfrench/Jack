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
    public class RoupaServiceApp :  IRoupaServiceApp
    {

        private readonly IRoupaService _service;

        public RoupaServiceApp(IRoupaService roupaService)
        {
            _service = roupaService;
        }


        public RoupaViewModel ObterPorId(int id)
        {
            var roupa = _service.ObterPorId(id);
            return Mapper.Map<RoupaViewModel>(roupa);
        }

        public IEnumerable<RoupaViewModel> ObterTodos()
        {
            var roupa = _service.ObterTodos();
            return Mapper.Map<IEnumerable<RoupaViewModel>>(roupa);
        }

 public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
