using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using System;
using System.Collections.Generic;
using Jack.Application.AutoMapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.Services;
using Jack.DomainValidator;

namespace Jack.Application
{
    public class NivelServiceApp :  INivelServiceApp
    {
       
        private readonly INivelService _service;
        private readonly IMapper mapper;

        public NivelServiceApp(INivelService nivelService)
        {
            mapper = AutoMapperConfig.Config.CreateMapper();
            _service = nivelService;
        }

        public IEnumerable<NivelViewModel> Filtrar(string nome)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Gravar(NivelViewModel nivel)
        {
            var nivelDado = mapper.Map<Nivel>(nivel);
            return _service.Gravar(nivelDado);
        }


        public ValidationResult Excluir(int id)
        {
            return _service.Excluir(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public NivelViewModel ObterPorId(int id)
        {
            var nivel = _service.ObterPorId(id);
            var nivelVm = mapper.Map<NivelViewModel>(nivel);
            return nivelVm;
        }

        public IEnumerable<NivelViewModel> ObterTodos()
        {
            var nivel = _service.ObterTodos();
            var nivelVm = mapper.Map<IEnumerable<NivelViewModel>>(nivel);
            return nivelVm;
        }
    }
}
