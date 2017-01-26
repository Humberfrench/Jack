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
    public class CalcadoServiceApp :  ICalcadoServiceApp
    {
        private readonly ICalcadoService _service;
        private readonly IMapper mapper;

        public CalcadoServiceApp(ICalcadoService calcadoService)
        {
            _service = calcadoService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public CalcadoViewModel ObterPorId(int id)
        {
            var calcado = _service.ObterPorId(id);
            return mapper.Map<Calcado, CalcadoViewModel>(calcado);
        }

        public IEnumerable<CalcadoViewModel> ObterTodos()
        {
            var calcado = _service.ObterTodos();
            var calcadoVm = mapper.Map<IEnumerable<Calcado>, IEnumerable<CalcadoViewModel>>(calcado);
            return calcadoVm;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

