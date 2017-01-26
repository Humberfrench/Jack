using System;
using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface ICriancaServiceApp : IServiceBase<CriancaViewModel>
    {
        IEnumerable<CriancaViewModel> ObterCriancas(int familia);
        IEnumerable<CriancaViewModel> ObterCriancasSacola(int familia);
        ValidationResult Gravar(CriancaViewModel entity);
        ValidationResult GravarDados(int crianca, int calcado, string roupa, int tipoParentesco);
        ValidationResult Excluir(int id);
        CriancaViewModel ValidaCrianca(CriancaValueViewModel criancaValue);
        ValidationResult AtualizaCriancas();
        ValidationResult AtualizaCriancas(int familiaId);
        ValidationResult AtualizaCrianca(CriancaViewModel crianca, bool gravar = true);
        Dictionary<string, string> ObterVestimentaPadrao(int idade, string medidaIdade, string sexo, bool isCriancaGrande = false);
        IEnumerable<CriancaVestimentaViewModel> ObterDadosCriancaVestimentas(int familia);

    }
}