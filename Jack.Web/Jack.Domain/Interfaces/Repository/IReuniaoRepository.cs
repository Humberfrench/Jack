using System;
using System.Collections.Generic;
using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IReuniaoRepository : IRepositoryBase<Reuniao>
    {
        bool ExisteData(DateTime data);
        IEnumerable<Reuniao> ObterTodosAteHoje(int ano, DateTime data);
    }
}