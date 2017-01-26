using System;
using System.Collections.Generic;
using AutoMapper;
using Jack.Application.AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using Jack.Domain.Entity;

namespace Jack.Application
{
    public class ParametroServiceApp : IParametroServiceApp
    {
        private readonly IParametroService _service;
        private readonly IMapper mapper;

        public ParametroServiceApp(IParametroService parametroService)
        {
            _service = parametroService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(ParametroViewModel item)
        {
            return _service.Gravar(mapper.Map<Parametro>(item));
        }

        public ParametroViewModel Obter()
        {
            return mapper.Map<ParametroViewModel>(_service.Obter());
        }
    }
}