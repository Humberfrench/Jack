using System;
using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface ICriancaServiceApp : IServiceBase<CriancaViewModel>
    {
        IEnumerable<CriancaViewModel> ObterCriancas(int familia);
        ValidationResult Gravar(CriancaViewModel entity);
        ValidationResult GravarVestimentas(int crianca, int calcado, string roupa);
        ValidationResult Excluir(int id);
        CriancaViewModel ValidaCrianca(CriancaValueViewModel criancaValue);
        Dictionary<string, string> ObterVestimentaPadrao(int idade, string medidaIdade, string sexo, bool isCriancaGrande = false);
        IEnumerable<CriancaVestimentaViewModel> ObterDadosCriancaVestimentas(int familia);

    }
}