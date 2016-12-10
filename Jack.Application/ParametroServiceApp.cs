using System;
using System.Collections.Generic;
using AutoMapper;
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

        public ParametroServiceApp(IParametroService parametroService)
        {
            _service = parametroService;
        }

        public ValidationResult Gravar(ParametroViewModel item)
        {
            return _service.Gravar(Mapper.Map<Parametro>(item));
        }

        public ParametroViewModel Obter()
        {
            return Mapper.Map<ParametroViewModel>(_service.Obter());
        }
    }
}