using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IColaboradorRepository : IRepositoryBase<Colaborador>
    {
        IEnumerable<QuantidadeSacolasColaborador> ObterQuantidadeSacolasColaborador(int ano, int nivelMaximo);
    }
}