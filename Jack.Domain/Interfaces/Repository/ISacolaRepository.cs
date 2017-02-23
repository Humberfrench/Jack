using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Repository
{
    public interface ISacolaRepository : IRepositoryBase<Sacola>
    {
        Sacola ObterSacolaPorCrianca(int crianca);
        IEnumerable<SacolaValue> ObterSacolaParaImpressao(string sacolasNumero, int ano);
    }
}