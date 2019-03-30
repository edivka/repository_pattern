using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.repositories.nhibernate
{

    public static class SessionFactory
    {

        const string CONNECTIONSTRING = "NorthwindConnectionString";

        /// <summary>
        /// Build session factory
        /// </summary>
        /// <returns></returns>
        public static ISessionFactory BuildNHibernateSessionFactory()
        {
            string currentStaticSession = ConfigurationManager.AppSettings["current-static-session"];
            if (string.IsNullOrEmpty(currentStaticSession))
            {
                currentStaticSession = "thread_static";
            }
            return BuildNHibernateSessionFactory(currentStaticSession);
        }

        /// <summary>
        /// Create the NHibernate Session Factory
        /// </summary>
        /// <param name="currentSessionContext"></param>
        /// <returns></returns>
        public static ISessionFactory BuildNHibernateSessionFactory(string currentSessionContext)
        {
            string connectionString = GetConnectionStringSettings();
            if (string.IsNullOrEmpty(connectionString))
                throw new ConfigurationErrorsException($"No [{CONNECTIONSTRING}] connection string key found in the configuration file");

            ISessionFactory factory = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012
                        .ConnectionString(connectionString)
                )
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<CustomerMapper>();
                })
                .ExposeConfiguration(
                    x => x.SetProperty("current_session_context_class", currentSessionContext)
                )
                .BuildSessionFactory();
            return factory;
        }

        /// <summary>
        /// Get the connection string settings based in the environment
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionStringSettings()
        {
            string cnnName = CONNECTIONSTRING;
            if (ConfigurationManager.ConnectionStrings[cnnName] != null)
                return ConfigurationManager.ConnectionStrings[cnnName].ConnectionString;
            else
                return string.Empty;
        }
    }
}
