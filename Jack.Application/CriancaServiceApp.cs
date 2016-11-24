using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using System;
using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
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

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
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


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
