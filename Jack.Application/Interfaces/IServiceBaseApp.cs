using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IServiceBase<TEntity>
      where TEntity : class
    {
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
    }
}