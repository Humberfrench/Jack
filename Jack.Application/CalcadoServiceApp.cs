using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class CalcadoServiceApp : AppServiceBase, ICalcadoServiceApp
    {
        private readonly ICalcadoService _service;

        public CalcadoServiceApp(ICalcadoService calcadoService)
        {
            _service = calcadoService;
        }

        public CalcadoViewModel ObterPorId(int id)
        {
            var calcado = _service.ObterPorId(id);
            return Mapper.Map<Calcado, CalcadoViewModel>(calcado);
        }

        public IEnumerable<CalcadoViewModel> ObterTodos()
        {
            var calcado = _service.ObterTodos();
            var calcadoVm = Mapper.Map<IEnumerable<Calcado>, IEnumerable<CalcadoViewModel>>(calcado);
            return calcadoVm;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

