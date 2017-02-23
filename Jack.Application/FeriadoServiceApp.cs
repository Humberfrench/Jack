using AutoMapper;
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
    public class FeriadoServiceApp :  IFeriadoServiceApp
    {
       
        private readonly IFeriadoService _service;
        private readonly IMapper mapper;

        public FeriadoServiceApp(IFeriadoService feriadoService)
        {
            _service = feriadoService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(FeriadoViewModel feriado)
        {
            var feriadoSalvar = mapper.Map<Feriado>(feriado);
            return _service.Gravar(feriadoSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public FeriadoViewModel ObterPorId(int id)
        {
            var feriado = _service.ObterPorId(id);
            return mapper.Map<FeriadoViewModel>(feriado);
        }

        public IEnumerable<FeriadoViewModel> ObterTodos()
        {
            var feriado = _service.ObterTodos();
            var retorno = mapper.Map<IEnumerable<FeriadoViewModel>>(feriado);
            return retorno;
        }

        public IEnumerable<FeriadoViewModel> Filtrar(string nome)
        {
            var feriado = _service.Filtrar(nome);
            return mapper.Map<IEnumerable<FeriadoViewModel>>(feriado);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
