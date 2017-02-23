using Jack.Domain.Interfaces;
using System.Linq;

namespace Jack.Repository.UnityOfWork
{
    public interface IRepository<T> where T : IEntidade
    {
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
