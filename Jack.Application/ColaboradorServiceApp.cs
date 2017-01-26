using System;
using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using System.Collections.Generic;
using Jack.Application.AutoMapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Application
{
    public class ColaboradorServiceApp :  IColaboradorServiceApp
    {
        private readonly IColaboradorService _service;
        private readonly IMapper mapper;

        public ColaboradorServiceApp(IColaboradorService colaboradorService)
        {
            _service = colaboradorService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(ColaboradorViewModel colaborador)
        {
            var colaboradorSalvar = mapper.Map<Colaborador>(colaborador);
            return _service.Gravar(colaboradorSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public ColaboradorViewModel ObterPorId(int id)
        {
            var colaborador = _service.ObterPorId(id);
            return mapper.Map<ColaboradorViewModel>(colaborador);
        }

        public IEnumerable<ColaboradorViewModel> ObterTodos()
        {
            var colaborador = _service.ObterTodos();
            return mapper.Map<IEnumerable<ColaboradorViewModel>>(colaborador);
        }

        public IEnumerable<ColaboradorViewModel> Filtrar(string nome)
        {
            var atividade = _service.Filtrar(nome);
            return mapper.Map<IEnumerable<ColaboradorViewModel>>(atividade);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

