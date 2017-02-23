using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;

namespace Jack.Domain.Interfaces.Repository
{
    public interface ICriancaRepository : IRepositoryBase<Crianca>
    {
        IEnumerable<CriancaVestimenta> ObterDadosCriancaVestimentas(int familia);     
    }
}