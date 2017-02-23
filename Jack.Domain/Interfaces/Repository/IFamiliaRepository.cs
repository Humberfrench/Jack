using Jack.Domain.Entity;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IFamiliaRepository : IRepositoryBase<Familia>
    {
        IEnumerable<Familia> ObterFamiliaPresencaJustificada();     
    }
}