using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class FamiliaServiceApp : IFamiliaServiceApp
    {

        private readonly IFamiliaService _service;

        public FamiliaServiceApp(IFamiliaService familiaService)
        {
            _service = familiaService;
        }

        public ValidationResult Gravar(FamiliaViewModel familia)
        {
            var familiaSalvar = Mapper.Map<Familia>(familia);
            return _service.Gravar(familiaSalvar);
        }

        public ValidationResult Gravar(FamiliaViewModel familia, int reuniao)
        {
            var familiaSalvar = Mapper.Map<Familia>(familia);
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
            var familiaSalvar = Mapper.Map<Familia>(familia);
            return _service.AtualizarPresencas(familiaSalvar);
        }

        public IEnumerable<FamiliaViewModel> ObterFamiliasBanidas()
        {
            var familia = _service.ObterFamiliasBanidas();
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public ValidationResult AtualizarFamiliaParaBanida(int familiaId)
        {
            return _service.AtualizarFamiliaParaBanida(familiaId);
        }

        public ValidationResult LiberarFamiliaBanida(int familiaId)
        {
            return _service.LiberarFamiliaBanida(familiaId);
        }

        public FamiliaViewModel ObterPorId(int id)
        {
            var familia = _service.ObterPorId(id);
            return Mapper.Map<FamiliaViewModel>(familia);
        }

        public IEnumerable<FamiliaViewModel> ObterTodos()
        {
            var familia = _service.ObterTodos();
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public IEnumerable<FamiliaViewModel> Filtrar(string nome)
        {
            var familia = _service.Filtrar(nome);
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<FamiliaViewModel> ObterNaoSacolas()
        {
            var familia = _service.ObterNaoSacolas();
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public IEnumerable<FamiliaViewModel> ObterPorStatus(int status)
        {
            var familia = _service.ObterPorStatus(status);
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }
    }
}
