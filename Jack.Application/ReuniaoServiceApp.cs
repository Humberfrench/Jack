using AutoMapper;
using Jack.Application.AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class ReuniaoServiceApp :  IReuniaoServiceApp
    {

        private readonly IReuniaoService _service;
        private readonly IMapper mapper;

        public ReuniaoServiceApp(IReuniaoService reuniaoService)
        {
            _service = reuniaoService;
            mapper = AutoMapperConfig.Config.CreateMapper();
        }

        public ValidationResult Gravar(ReuniaoViewModel reuniao)
        {
            var reuniaoSalvar = mapper.Map<Reuniao>(reuniao);
            return _service.Gravar(reuniaoSalvar);
        }

        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public IEnumerable<ReuniaoViewModel> ObterReunioesNoAno()
        {
            var reuniao = _service.ObterReunioesNoAno();
            return mapper.Map<IEnumerable<ReuniaoViewModel>>(reuniao);
        }

        public IEnumerable<ReuniaoViewModel> ObterReunioesNoAno(int ano)
        {
            var reuniao = _service.ObterReunioesNoAno(ano);
            return mapper.Map<IEnumerable<ReuniaoViewModel>>(reuniao);
        }

        public ValidationResult MontarDataReuniao(int ano)
        {
            return _service.MontarDataReuniao(ano);
        }

        public ReuniaoViewModel ObterPorId(int id)
        {
            var reuniao = _service.ObterPorId(id);
            return mapper.Map<ReuniaoViewModel>(reuniao);
        }

        public IEnumerable<ReuniaoViewModel> ObterTodos()
        {
            var reuniao = _service.ObterTodos();
            return mapper.Map<IEnumerable<ReuniaoViewModel>>(reuniao);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
