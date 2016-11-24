using System;
using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface ICriancaService : IServiceBase<Crianca>
    {
        IEnumerable<Crianca> ObterCriancas(int familia);
        ValidationResult Gravar(Crianca entity);
        ValidationResult Excluir(int id);
        bool ValidaCalcado(string sexo, int idade, string medidaIdade, int calcado);
        bool ValidaRoupa(string sexo, int idade, string medidaIdade, bool isCriancaGrande, string roupa);
        Crianca ValidaCrianca(DateTime dataNasc, string sexo, bool cadastroNovo = false, bool necessidadeEspecial = false);
        void AtualizaCriancas();
        Crianca AtualizaCrianca(Crianca crianca, bool gravar = true);
    }
}