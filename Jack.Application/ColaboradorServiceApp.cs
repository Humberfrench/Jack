using System;
using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Application
{
    public class ColaboradorServiceApp :  IColaboradorServiceApp
    {
        private readonly IColaboradorService _service;

        public ColaboradorServiceApp(IColaboradorService ColaboradorService)
        {
            _service = ColaboradorService;
        }

        public ValidationResult Gravar(ColaboradorViewModel Colaborador)
        {
            var ColaboradorSalvar = Mapper.Map<Colaborador>(Colaborador);
            return _service.Gravar(ColaboradorSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public ColaboradorViewModel ObterPorId(int id)
        {
            var Colaborador = _service.ObterPorId(id);
            return Mapper.Map<ColaboradorViewModel>(Colaborador);
        }

        public IEnumerable<ColaboradorViewModel> ObterTodos()
        {
            var Colaborador = _service.ObterTodos();
            return Mapper.Map<IEnumerable<ColaboradorViewModel>>(Colaborador);
        }

        public IEnumerable<ColaboradorViewModel> Filtrar(string nome)
        {
            var atividade = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<ColaboradorViewModel>>(atividade);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

