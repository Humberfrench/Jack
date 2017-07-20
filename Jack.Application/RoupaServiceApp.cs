using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class RoupaServiceApp : AppServiceBase, IRoupaServiceApp
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
