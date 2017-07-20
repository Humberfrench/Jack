using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Jack.Domain.Services
{
    public class ServiceBaseReadOnly<TEntity> : IDisposable, IServiceBaseReadOnly<TEntity> where TEntity : class
    {
        private readonly IRepositoryBaseReadOnly<TEntity> _repository;

        public ServiceBaseReadOnly(IRepositoryBaseReadOnly<TEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public TEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Pesquisar(predicate);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
