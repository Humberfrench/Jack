using Jack.Model;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Data
{
    public class Repository<T> : IRepository<T> where T : IEntidade
    {
        private UnitWork _unitOfWork;
        public Repository(IUnitWork unitOfWork)
        {
            _unitOfWork = (UnitWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

    }
}
