using NHibernate;
using NHibernate.Cfg;
using System;

namespace Jack.Data
{
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";

        private static readonly ISessionFactory sessionFactory;
        static NHibernateHelper()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession GetCurrentSession(System.Reflection.Assembly assembly)
        {
            ISession currentSession = assembly as ISession;
            try
            {
                if (currentSession == null)
                {
                    currentSession = sessionFactory.OpenSession();
                }
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
    }
}
