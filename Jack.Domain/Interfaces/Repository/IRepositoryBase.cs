using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable
      where TEntity : class
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate);
    }
}