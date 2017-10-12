using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Inspections;
using Jack.Domain.Interfaces;
using NHibernate;
using NHibernate.Cfg;

namespace Jack.Repository.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private static readonly ISessionFactory SessionFactory;
        private ITransaction _transaction;
        private const string CURRENT_SESSION_KEY = "nhibernate.current_session";
        private static readonly object Factorylock = new object();

        public ISession Session { get; private set; }

        static UnityOfWork()
        {
            lock (Factorylock)
            {
                var cfg = new Configuration();
                cfg.Configure();

                SessionFactory = Fluently.Configure(cfg)
                                .Diagnostics(d => d.Enable().OutputToConsole())
                                .CurrentSessionContext("web")
                                .Mappings(m =>
                                            m.FluentMappings
                                                .AddFromAssemblyOf<UnityOfWork>()
                                                .Conventions.AddFromAssemblyOf<UnityOfWork>()
                                                .Conventions.Add(DefaultAccess.CamelCaseField(CamelCasePrefix.None))
                                                )
                                .BuildSessionFactory();

            }

        }
        public void Salvar(IEntidade entidade)
        {
            BeginTransaction();
            Session.SaveOrUpdate(entidade);
            Commit();
        }

        public void Excluir(IEntidade entidade)
        {
            BeginTransaction();
            Session.Delete(entidade);
            Commit();
        }

        public UnityOfWork()
        {
            Session = SessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
        }

    }
}

