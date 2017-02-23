using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IColaboradorRepository : IRepositoryBase<Colaborador>
    {
        IEnumerable<QuantidadeSacolasColaborador> ObterQuantidadeSacolasColaborador(int ano, int nivelMaximo);
    }
}