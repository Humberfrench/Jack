using System;
using System.Collections.Generic;
using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IRoupaRepository : IRepositoryBaseReadOnly<Roupa>
    {
        //Tuple<string, string> ObterPorSexoIdade(string sexo, int idade, string medidaIdade);   
        dynamic ObterPorSexoIdade(string sexo, int idade, string medidaIdade);   
    }
}