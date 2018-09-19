using Jack.Domain.Interfaces;
using System;
using System.Linq;

namespace Jack.Repository.UnityOfWork
{
    public interface IRepository<T> : IDisposable where T : IEntidade
    {
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
