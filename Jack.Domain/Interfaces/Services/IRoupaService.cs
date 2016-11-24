using System;
using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IRoupaService : IServiceBaseReadOnly<Roupa>
    {
        //Tuple<string, string> ObterPorSexoIdade(string sexo, int idade, string medidaIdade);   
        dynamic ObterPorSexoIdade(string sexo, int idade, string medidaIdade);
    }
}