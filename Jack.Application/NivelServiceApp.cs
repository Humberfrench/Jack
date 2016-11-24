using AutoMapper;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using System;
using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.Services;
using Jack.DomainValidator;

namespace Jack.Application
{
    public class NivelServiceApp :  INivelServiceApp
    {
       
        private readonly INivelService _service;
        //readonly IMapper Mapper;

        public NivelServiceApp(INivelService nivelService)
        {
            _service = nivelService;
        }

        public IEnumerable<NivelViewModel> Filtrar(string nome)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Gravar(NivelViewModel nivel)
        {
            var nivelDado = Mapper.Map<Nivel>(nivel);
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
            var nivelVm = Mapper.Map<NivelViewModel>(nivel);
            return nivelVm;
        }

        public IEnumerable<NivelViewModel> ObterTodos()
        {
            var nivel = _service.ObterTodos();
            var nivelVm = Mapper.Map<IEnumerable<NivelViewModel>>(nivel);
            return nivelVm;
        }
    }
}
