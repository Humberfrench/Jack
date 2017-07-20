using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class PresencaServiceApp : AppServiceBase, IPresencaServiceApp
    {

        private readonly IPresencaService _service;

        public PresencaServiceApp(IPresencaService presencaService)
        {
            _service = presencaService;
        }

        public ValidationResult Gravar(int reuniao, int familia)
        {
            return _service.Gravar(reuniao, familia);
        }

        public ValidationResult Gravar(ReuniaoViewModel reuniao, FamiliaViewModel familia)
        {

            var familiaD = Mapper.Map<Familia>(familia);

            var reuniaoD = Mapper.Map<Reuniao>(reuniao);

            return _service.Gravar(reuniaoD, familiaD);

        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public List<StatsViewModel> ObterDadosPresenca(int familiaId)
        {

            var presenca = _service.ObterDadosPresenca(familiaId);

            return Mapper.Map<List<StatsViewModel>>(presenca);

        }

        public IEnumerable<FamiliaViewModel> ObterFamiliasDisponiveis(int reuniao)
        {
            var presenca = _service.ObterFamiliasDisponiveis(reuniao);
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(presenca);
        }

        public IEnumerable<FamiliaViewModel> ObterFamiliasDisponiveis(int reuniao, string letra)
        {
            var presenca = _service.ObterFamiliasDisponiveis(reuniao, letra);
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(presenca);
        }

        public ValidationResult ProcessarPresencaGarantida()
        {
            return _service.ProcessarPresencaGarantida();
        }

        public PresencaViewModel ObterPorId(int id)
        {
            var presenca = _service.ObterPorId(id);
            return Mapper.Map<PresencaViewModel>(presenca);
        }

        public IEnumerable<PresencaViewModel> ObterTodos()
        {
            var presenca = _service.ObterTodos();
            return Mapper.Map<IEnumerable<PresencaViewModel>>(presenca);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
