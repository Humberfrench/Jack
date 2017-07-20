using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class CriancaServiceApp : AppServiceBase, ICriancaServiceApp
    {

        private readonly ICriancaService criancaService;

        public CriancaServiceApp(ICriancaService criancaService)
        {
            this.criancaService = criancaService;
        }

        public ValidationResult Gravar(CriancaViewModel crianca)
        {
            var criancaSalvar = Mapper.Map<Crianca>(crianca);
            return criancaService.Gravar(criancaSalvar);
        }

        public ValidationResult GravarDados(int crianca, int calcado, string roupa, int tipoParentesco)
        {
            return criancaService.GravarDados(crianca, calcado, roupa, tipoParentesco);
        }

        public ValidationResult Excluir(int id)
        {
            return criancaService.Excluir(id);
        }

        public CriancaViewModel ValidaCrianca(CriancaValueViewModel criancaValue)
        {
            var paramCrianca = Mapper.Map<CriancaValue>(criancaValue);
            var crianca = criancaService.ValidaCrianca(paramCrianca);
            return Mapper.Map<CriancaViewModel>(crianca);
        }

        public ValidationResult AtualizaCriancas()
        {
            return criancaService.AtualizaCriancas();
        }

        public ValidationResult AtualizaCriancas(int familiaId)
        {
            return criancaService.AtualizaCriancas(familiaId);
        }

        public ValidationResult AtualizaCriancas(bool todas)
        {
            return criancaService.AtualizaCriancas(todas);
        }

        public ValidationResult AtualizaCrianca(int id, bool gravar)
        {
            return criancaService.AtualizaCrianca(id, gravar);
        }

        public ValidationResult AtualizaCrianca(CriancaViewModel crianca, bool gravar)
        {
            var criancaValor = Mapper.Map<Crianca>(crianca);
            return criancaService.AtualizaCrianca(criancaValor, gravar);
        }

        public Dictionary<string, string> ObterVestimentaPadrao(int idade, string medidaIdade, string sexo, bool isCriancaGrande = false)
        {
            return criancaService.ObterVestimentaPadrao(idade, medidaIdade, sexo, isCriancaGrande);
        }

        public IEnumerable<CriancaVestimentaViewModel> ObterDadosCriancaVestimentas(int familia)
        {
            var crianca = criancaService.ObterDadosCriancaVestimentas(familia);
            return Mapper.Map<IEnumerable<CriancaVestimentaViewModel>>(crianca);
        }

        public CriancaViewModel ObterPorId(int id)
        {
            var crianca = criancaService.ObterPorId(id);
            return Mapper.Map<CriancaViewModel>(crianca);
        }

        public IEnumerable<CriancaViewModel> ObterTodos()
        {
            var crianca = criancaService.ObterTodos();
            return Mapper.Map<IEnumerable<CriancaViewModel>>(crianca);
        }

        public IEnumerable<CriancaViewModel> ObterCriancas(int familia)
        {
            var crianca = criancaService.ObterCriancas(familia);
            return Mapper.Map<IEnumerable<CriancaViewModel>>(crianca);
        }

        public IEnumerable<CriancaViewModel> ObterCriancasSacola(int familia)
        {
            var crianca = criancaService.ObterCriancasSacola(familia);
            return Mapper.Map<IEnumerable<CriancaViewModel>>(crianca);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ValidationResult AtualizaCriancasMaiores()
        {
            return criancaService.AtualizaCriancasMaiores();
        }
    }
}
