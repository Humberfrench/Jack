using System;
using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface ICriancaService : IServiceBase<Crianca>
    {
        IEnumerable<Crianca> ObterCriancas(int familia);
        IEnumerable<Crianca> ObterCriancasSacola(int familia);
        ValidationResult Gravar(Crianca entity);
        ValidationResult GravarVestimentas(int crianca, int calcado, string roupa);
        ValidationResult Excluir(int id);
        bool ValidaCalcado(string sexo, int idade, string medidaIdade, int calcado);
        bool ValidaRoupa(string sexo, int idade, string medidaIdade, bool isCriancaGrande, string roupa);
        Crianca ValidaCrianca(CriancaValue criancaValue);
        void AtualizaCriancas();
        Crianca AtualizaCrianca(Crianca crianca, bool gravar = true);
        Dictionary<string, string> ObterVestimentaPadrao(int idade, string medidaIdade, string sexo, bool isCriancaGrande = false);
        IEnumerable<CriancaVestimenta> ObterDadosCriancaVestimentas(int familia);
    }
}