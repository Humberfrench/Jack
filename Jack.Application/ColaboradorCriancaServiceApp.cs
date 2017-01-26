using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;
using Jack.Application.AutoMapper;

namespace Jack.Application
{
    public class ColaboradorCriancaServiceApp :  IColaboradorCriancaServiceApp
    {

        private readonly IColaboradorCriancaService _service;
        private readonly IMapper mapper;

        public ColaboradorCriancaServiceApp(IColaboradorCriancaService colaboradorCriancaService)
        {
            _service = colaboradorCriancaService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public IEnumerable<ColaboradorCriancaViewModel> Obter(int id, int ano)
        {
            var colaboradorCrianca = _service.Obter(id,ano);
            return mapper.Map<IEnumerable<ColaboradorCriancaViewModel>>(colaboradorCrianca);
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
            return mapper.Map<ColaboradorCriancaViewModel>(colaboradorCrianca);
        }

        public IEnumerable<ColaboradorCriancaViewModel> ObterTodos()
        {
            var colaboradorCrianca = _service.ObterTodos();
            return mapper.Map<IEnumerable<ColaboradorCriancaViewModel>>(colaboradorCrianca);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
