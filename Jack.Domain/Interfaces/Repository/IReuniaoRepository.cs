using Jack.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IReuniaoRepository : IRepositoryBase<Reuniao>
    {
        bool ExisteData(DateTime data);
        IEnumerable<Reuniao> ObterTodosAteHoje(int ano);
    }
}