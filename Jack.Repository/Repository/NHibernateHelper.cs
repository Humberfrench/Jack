using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Inspections;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using System;

namespace Jack.Repository
{
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static object factorylock = new object();

        private static readonly ISessionFactory sessionFactory;
        static NHibernateHelper()
        {
            try
            {
                lock (factorylock)
                {
                    Configuration cfg = new Configuration();
                    cfg.Configure();

                    sessionFactory = Fluently.Configure(cfg)
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

        public static ISession GetCurrentSession(System.Reflection.Assembly assembly)
        {
            ISession currentSession = assembly as ISession;
            try
            {
                if (currentSession == null)
                {
                    currentSession = sessionFactory.OpenSession();
                    currentSession = currentSession.GetSession(EntityMode.Poco);
                }
                else
                {
                    if (!currentSession.IsConnected)
                    {
                        currentSession = sessionFactory.GetCurrentSession();
                    }
                }
                if (!CurrentSessionContext.HasBind(sessionFactory))
                        CurrentSessionContext.Bind(sessionFactory.OpenSession());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return currentSession;
        }

        public static void CloseSession(System.Reflection.Assembly assembly)
        {
            ISession currentSession = assembly as ISession;
            try
            {
                if (currentSession == null)
                {
                    // No current session
                    return;
                }

                currentSession.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
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
//An association from the table tb_reuniao_agendada refers to an unmapped 
//    class: System.Collections.Generic.List`1[[Jack.Model.Presenca, 
//    Jack.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]