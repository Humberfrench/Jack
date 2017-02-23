using System;
using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IRoupaRepository : IRepositoryBaseReadOnly<Roupa>
    {
        //Tuple<string, string> ObterPorSexoIdade(string sexo, int idade, string medidaIdade);   
        RoupaValue ObterPorIdade(int idade, string medidaIdade);
        string ObterPorIdade(int idade, string medidaIdade, bool isCriancaGrande);
    }
}