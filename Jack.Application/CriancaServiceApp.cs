using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;

namespace Jack.Application
{
    public class CriancaServiceApp :  ICriancaServiceApp
    {

        private readonly ICriancaService _service;

        public CriancaServiceApp(ICriancaService criancaService)
        {
            _service = criancaService;
        }

        public ValidationResult Gravar(CriancaViewModel crianca)
        {
            var criancaSalvar = Mapper.Map<Crianca>(crianca);
            return _service.Gravar(criancaSalvar);
        }

        public ValidationResult GravarVestimentas(int crianca, int calcado, string roupa)
        {
            return _service.GravarVestimentas(crianca, calcado, roupa);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public CriancaViewModel ValidaCrianca(CriancaValueViewModel criancaValue)
        {
            var paramCrianca = Mapper.Map<CriancaValue>(criancaValue);
            var crianca = _service.ValidaCrianca(paramCrianca);
            return Mapper.Map<CriancaViewModel>(crianca);
        }

        public Dictionary<string, string> ObterVestimentaPadrao(int idade, string medidaIdade, string sexo, bool isCriancaGrande = false)
        {
            return _service.ObterVestimentaPadrao(idade, medidaIdade, sexo, isCriancaGrande);
        }

        public IEnumerable<CriancaVestimentaViewModel> ObterDadosCriancaVestimentas(int familia)
        {
            var crianca = _service.ObterDadosCriancaVestimentas(familia);
            return Mapper.Map<IEnumerable<CriancaVestimentaViewModel>>(crianca);
        }

        public CriancaViewModel ObterPorId(int id)
        {
            var crianca = _service.ObterPorId(id);
            return Mapper.Map<CriancaViewModel>(crianca);
        }

        public IEnumerable<CriancaViewModel> ObterTodos()
        {
            var crianca = _service.ObterTodos();
            return Mapper.Map<IEnumerable<CriancaViewModel>>(crianca);
        }

        public IEnumerable<CriancaViewModel> ObterCriancas(int familia)
        {
            var crianca = _service.ObterCriancas(familia);
            return Mapper.Map<IEnumerable<CriancaViewModel>>(crianca);
        }

        public IEnumerable<CriancaViewModel> ObterCriancasSacola(int familia)
        {
            var crianca = _service.ObterCriancasSacola(familia);
            return Mapper.Map<IEnumerable<CriancaViewModel>>(crianca);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
