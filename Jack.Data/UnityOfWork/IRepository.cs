using Jack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Data
{
    public interface IRepository<T> where T : IEntidade
    {
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
