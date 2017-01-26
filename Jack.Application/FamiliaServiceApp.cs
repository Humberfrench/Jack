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
    public class FamiliaServiceApp :  IFamiliaServiceApp
    {

        private readonly IFamiliaService _service;
        private readonly IMapper mapper;

        public FamiliaServiceApp(IFamiliaService familiaService)
        {
            mapper = AutoMapperConfig.Config.CreateMapper();
            _service = familiaService;
        }

        public ValidationResult Gravar(FamiliaViewModel familia)
        {
            var familiaSalvar = mapper.Map<Familia>(familia);
            return _service.Gravar(familiaSalvar);
        }

        public ValidationResult Gravar(FamiliaViewModel familia, int reuniao)
        {
            var familiaSalvar = mapper.Map<Familia>(familia);
            return _service.Gravar(familiaSalvar, reuniao);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public ValidationResult AtualizarFamilia(int id, bool gravar = true)
        {
            var familia = _service.AtualizarFamilia(id, gravar);
            return familia;
        }

        public ValidationResult AtualizarPresencas(FamiliaViewModel familia)
        {
            var familiaSalvar = mapper.Map<Familia>(familia);
            return _service.AtualizarPresencas(familiaSalvar);
        }

        public FamiliaViewModel ObterPorId(int id)
        {
            var familia = _service.ObterPorId(id);
            return mapper.Map<FamiliaViewModel>(familia);
        }

        public IEnumerable<FamiliaViewModel> ObterTodos()
        {
            var familia = _service.ObterTodos();
            return mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public IEnumerable<FamiliaViewModel> Filtrar(string nome)
        {
            var familia = _service.Filtrar(nome);
            return mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
