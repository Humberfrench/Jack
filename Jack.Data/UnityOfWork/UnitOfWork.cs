using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Inspections;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using System;

namespace Jack.Data
{
    class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static object factorylock = new object();

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the
            // application lifetime - the first time the UnitOfWork class is used
            //_sessionFactory = Fluently.Configure()
            //    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("UnitOfWorkExample")))
            //    .Mappings(x => x.AutoMappings.Add(
            //        AutoMap.AssemblyOf<Product>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<ProductOverrides>()))
            //    .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
            //    .BuildSessionFactory();
            try
            {
                lock (factorylock)
                {
                    Configuration cfg = new Configuration();
                    cfg.Configure();

                    _sessionFactory = Fluently.Configure(cfg)
                                    .CurrentSessionContext("web")
                                    .Mappings(m =>
                                                m.FluentMappings
                                                    .AddFromAssemblyOf<NHibernateHelper>()
                                                    .Conventions.AddFromAssemblyOf<NHibernateHelper>()
                                                    .Conventions.Add(DefaultAccess.CamelCaseField(CamelCasePrefix.None)))
                                    .BuildSessionFactory();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
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
            finally
            {
                Session.Close();
            }
        }

        public static void CreationDB()
        {
            FluentConfiguration config = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString("Data Source=.\\Web;Initial Catalog=dbCECAM16;Integrated Security=False;User ID=sa;Password=123456"))
                .Mappings(m => m.FluentMappings.Add<Map.MapCalcado>())
                .Mappings(m => m.FluentMappings.Add<Map.MapColaborador>())
                .Mappings(m => m.FluentMappings.Add<Map.MapColaboradorCrianca>())
                .Mappings(m => m.FluentMappings.Add<Map.MapCriancas>())
                .Mappings(m => m.FluentMappings.Add<Map.MapFamilia>())
                .Mappings(m => m.FluentMappings.Add<Map.MapKit>())
                .Mappings(m => m.FluentMappings.Add<Map.MapKitItem>())
                .Mappings(m => m.FluentMappings.Add<Map.MapPresenca>())
                .Mappings(m => m.FluentMappings.Add<Map.MapReuniao>())
                .Mappings(m => m.FluentMappings.Add<Map.MapRoupa>())
                .Mappings(m => m.FluentMappings.Add<Map.MapStatus>())
                .Mappings(m => m.FluentMappings.Add<Map.MapCriancaMoralCrista>())
                .Mappings(m => m.FluentMappings.Add<Map.MapResponsavel>())
                .Mappings(m => m.FluentMappings.Add<Map.MapTipoItem>());

            config.ExposeConfiguration(
                      c => new SchemaExport(c).Execute(true, true, false))
                 .BuildConfiguration();
        }
    }
}
}
