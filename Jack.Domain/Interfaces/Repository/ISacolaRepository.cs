using Jack.Domain.Entity;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Repository
{
    public interface ISacolaRepository : IRepositoryBase<Sacola>
    {
        Sacola ObterSacolaPorCrianca(int crianca);
        IEnumerable<Familia> ObterFamilias(int nivel);
    }
}