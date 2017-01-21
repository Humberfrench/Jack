using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class ColaboradorCriancaServiceApp :  IColaboradorCriancaServiceApp
    {

        private readonly IColaboradorCriancaService _service;

        public ColaboradorCriancaServiceApp(IColaboradorCriancaService colaboradorCriancaService)
        {
            _service = colaboradorCriancaService;
        }

        public IEnumerable<ColaboradorCriancaViewModel> Obter(int id, int ano)
        {
            var colaboradorCrianca = _service.Obter(id,ano);
            return Mapper.Map<IEnumerable<ColaboradorCriancaViewModel>>(colaboradorCrianca);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public ValidationResult AdicionaColaboradorCrianca(int colaborador, int crianca, int ano)
        {
            return _service.AdicionaColaboradorCrianca(colaborador, crianca, ano);
        }

        public ValidationResult AdicionaColaboradorSacola(int colaborador, int sacola, int ano)
        {
            return _service.AdicionaColaboradorCrianca(colaborador, sacola, ano);
        }

        public ValidationResult AdicionarSacolas(int colaborador, string sacolas, int ano)
        {
            return _service.AdicionarSacolas(colaborador, sacolas, ano);
        }

        public ValidationResult DevolveuSacola(int colaborador, int sacola, int ano)
        {
            return _service.DevolveuSacola(colaborador, sacola, ano);
        }

        public ColaboradorCriancaViewModel ObterPorId(int id)
        {
            var colaboradorCrianca = _service.ObterPorId(id);
            return Mapper.Map<ColaboradorCriancaViewModel>(colaboradorCrianca);
        }

        public IEnumerable<ColaboradorCriancaViewModel> ObterTodos()
        {
            var colaboradorCrianca = _service.ObterTodos();
            return Mapper.Map<IEnumerable<ColaboradorCriancaViewModel>>(colaboradorCrianca);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
