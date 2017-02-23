using System;
using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IRoupaService : IServiceBaseReadOnly<Roupa>
    {
        //Tuple<string, string> ObterPorSexoIdade(string sexo, int idade, string medidaIdade);   
        RoupaValue ObterPorSexoIdade( int idade, string medidaIdade);
        string ObterPorSexoIdade(int idade, string medidaIdade, bool criancaGrande);
    }
}