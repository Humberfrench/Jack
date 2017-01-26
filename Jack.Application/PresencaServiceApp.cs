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
    public class PresencaServiceApp :  IPresencaServiceApp
    {

        private readonly IPresencaService _service;
        private readonly IMapper mapper;

        public PresencaServiceApp(IPresencaService presencaService)
        {
            _service = presencaService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(int reuniao, int familia)
        {
            return _service.Gravar(reuniao, familia);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public List<StatsViewModel> ObterDadosPresenca(int familiaId)
        {
            var presenca = _service.ObterDadosPresenca(familiaId);
            return mapper.Map<List<StatsViewModel>>(presenca);
        }

        public IEnumerable<FamiliaViewModel> ObterFamiliasDisponiveis(int reuniao)
        {
            var presenca = _service.ObterFamiliasDisponiveis(reuniao);
            return mapper.Map<IEnumerable<FamiliaViewModel>>(presenca);
        }

        public IEnumerable<FamiliaViewModel> ObterFamiliasDisponiveis(int reuniao, string letra)
        {
            var presenca = _service.ObterFamiliasDisponiveis(reuniao, letra);
            return mapper.Map<IEnumerable<FamiliaViewModel>>(presenca);
        }

        public PresencaViewModel ObterPorId(int id)
        {
            var presenca = _service.ObterPorId(id);
            return mapper.Map<PresencaViewModel>(presenca);
        }

        public IEnumerable<PresencaViewModel> ObterTodos()
        {
            var presenca = _service.ObterTodos();
            return mapper.Map<IEnumerable<PresencaViewModel>>(presenca);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
