using System.Linq;
using Jack.Domain.Interfaces;

namespace Jack.Repository.UnityOfWork
{
    public interface IRepository<T> where T : IEntidade
    {
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
