using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IServiceBase<TEntity>
      where TEntity : class
    {
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
    }
}