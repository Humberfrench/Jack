using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class FamiliaServiceApp : AppServiceBase, IFamiliaServiceApp
    {

        private readonly IFamiliaService service;

        public FamiliaServiceApp(IFamiliaService familiaService)
        {
            service = familiaService;
        }

        public string ObterRepresentante(int familiaId)
        {
            return service.ObterRepresentante(familiaId);
        }

        public ValidationResult Gravar(FamiliaViewModel familia)
        {
            var familiaSalvar = Mapper.Map<Familia>(familia);
            return service.Gravar(familiaSalvar);
        }

        public ValidationResult Gravar(FamiliaViewModel familia, int reuniao)
        {
            var familiaSalvar = Mapper.Map<Familia>(familia);
            return service.Gravar(familiaSalvar, reuniao);
        }

        public ValidationResult Excluir(int id)
        {
            return service.Excluir(id);
        }
        public ValidationResult AtualizarSimSacola(int familiaId)
        {
            return service.AtualizarSimSacola(familiaId);
        }

        public ValidationResult AtualizarFamiliaComPresencaParaRepresentantes(int id, bool gravar = true)
        {
            return service.AtualizarFamiliaComPresencaParaRepresentantes(id,gravar);
        }

        public ValidationResult AtualizarFamilia(int id, bool gravar = true)
        {
            var familia = service.AtualizarFamilia(id, gravar);
            return familia;
        }

        public ValidationResult AtualizarPresencas(FamiliaViewModel familia)
        {
            var familiaSalvar = Mapper.Map<Familia>(familia);
            return service.AtualizarPresencas(familiaSalvar);
        }

        public IEnumerable<FamiliaViewModel> ObterFamiliasBanidas()
        {
            var familia = service.ObterFamiliasBanidas();
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public ValidationResult AtualizarFamiliaParaBanida(int familiaId)
        {
            return service.AtualizarFamiliaParaBanida(familiaId);
        }

        public ValidationResult LiberarFamiliaBanida(int familiaId)
        {
            return service.LiberarFamiliaBanida(familiaId);
        }


        public FamiliaViewModel ObterPorId(int id)
        {
            var familia = service.ObterPorId(id);
            return Mapper.Map<FamiliaViewModel>(familia);
        }

        public IEnumerable<FamiliaViewModel> ObterTodos()
        {
            var familia = service.ObterTodos();
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public IEnumerable<FamiliaViewModel> Filtrar(string nome)
        {
            var familia = service.Filtrar(nome);
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<FamiliaViewModel> ObterNaoSacolas()
        {
            var familia = service.ObterNaoSacolas();
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public IEnumerable<FamiliaViewModel> ObterPorStatus(int status)
        {
            var familia = service.ObterPorStatus(status);
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }

        public IEnumerable<FamiliaViewModel> ObterTodosTratamento()
        {
            var familia = service.ObterTodosTratamento();
            return Mapper.Map<IEnumerable<FamiliaViewModel>>(familia);
        }
    }
}
