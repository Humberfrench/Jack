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
    public class ReuniaoServiceApp :  IReuniaoServiceApp
    {

        private readonly IReuniaoService _service;

        public ReuniaoServiceApp(IReuniaoService reuniaoService)
        {
            _service = reuniaoService;
        }

        public ValidationResult Gravar(ReuniaoViewModel reuniao)
        {
            var reuniaoSalvar = Mapper.Map<Reuniao>(reuniao);
            return _service.Gravar(reuniaoSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public IEnumerable<ReuniaoViewModel> ObterReunioesNoAno()
        {
            var reuniao = _service.ObterReunioesNoAno();
            return Mapper.Map<IEnumerable<ReuniaoViewModel>>(reuniao);
        }

        public IEnumerable<ReuniaoViewModel> ObterReunioesNoAno(int ano)
        {
            var reuniao = _service.ObterReunioesNoAno(ano);
            return Mapper.Map<IEnumerable<ReuniaoViewModel>>(reuniao);
        }

        public ReuniaoViewModel ObterPorId(int id)
        {
            var reuniao = _service.ObterPorId(id);
            return Mapper.Map<ReuniaoViewModel>(reuniao);
        }

        public IEnumerable<ReuniaoViewModel> ObterTodos()
        {
            var reuniao = _service.ObterTodos();
            return Mapper.Map<IEnumerable<ReuniaoViewModel>>(reuniao);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
