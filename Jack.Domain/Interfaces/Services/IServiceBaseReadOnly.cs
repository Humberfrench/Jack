using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Jack.Domain.Interfaces.Services
{
    public interface IServiceBaseReadOnly<TEntity> : IDisposable
      where TEntity : class
    {
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate);
    }
}