﻿using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IParametroRepository : IRepositoryBaseReadOnly<Parametro>
    {
        Parametro Obter();
    }
}