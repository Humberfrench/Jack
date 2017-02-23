using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Repository
{
    public interface ICriancaRepository : IRepositoryBase<Crianca>
    {
        IEnumerable<CriancaVestimenta> ObterDadosCriancaVestimentas(int familia);     
    }
}