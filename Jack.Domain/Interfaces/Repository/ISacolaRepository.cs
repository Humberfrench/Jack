using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Repository
{
    public interface ISacolaRepository : IRepositoryBase<Sacola>
    {
        Sacola ObterSacolaPorCrianca(int crianca);
        IEnumerable<Familia> ObterFamilias(int nivel);
        IEnumerable<SacolaDto> ObterSacolasLivres(int ano, int liberado, int nivel, int kit);
    }
}