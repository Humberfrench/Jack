using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class ColaboradorServiceApp : AppServiceBase, IColaboradorServiceApp
    {
        private readonly IColaboradorService _service;

        public ColaboradorServiceApp(IColaboradorService colaboradorService)
        {
            _service = colaboradorService;
        }

        public ValidationResult Gravar(ColaboradorViewModel colaborador)
        {
            var colaboradorSalvar = Mapper.Map<Colaborador>(colaborador);
            return _service.Gravar(colaboradorSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public IEnumerable<ColaboradorCriancaViewModel> ObterSacolasColaborador(int colaborador)
        {
            var criancas = _service.ObterSacolasColaborador(colaborador);
            return Mapper.Map<IEnumerable<ColaboradorCriancaViewModel>>(criancas);
        }

        public IEnumerable<ColaboradorCriancaViewModel> ObterSacolasColaborador(int colaborador, int ano)
        {
            var criancas = _service.ObterSacolasColaborador(colaborador, ano);
            return Mapper.Map<IEnumerable<ColaboradorCriancaViewModel>>(criancas);
        }

        public ColaboradorViewModel ObterPorId(int id)
        {
            var colaborador = _service.ObterPorId(id);
            return Mapper.Map<ColaboradorViewModel>(colaborador);
        }

        public IEnumerable<ColaboradorViewModel> ObterTodos()
        {
            var colaborador = _service.ObterTodos();
            return Mapper.Map<IEnumerable<ColaboradorViewModel>>(colaborador);
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

