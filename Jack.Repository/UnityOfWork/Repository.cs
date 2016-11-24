using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Linq.Expressions;
using Jack.Domain.Interfaces;

namespace Jack.Repository.UnityOfWork
{
    public class Repository<T> : IRepository<T> where T : IEntidade
    {
        private readonly UnityOfWork _unitOfWork;

        public Repository(IUnityOfWork unitOfWork)
        {
            _unitOfWork = (UnityOfWork)unitOfWork;
        }

        protected ISession Session
        {
            get
            {
                return _unitOfWork.Session;
            }
        }
        protected IDbConnection Conn
        {
            get
            {
                return _unitOfWork.Session.Connection;
            }
        }
        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }
        public virtual IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            return Session.Query<T>().Where(predicate);
        }

    }
}
