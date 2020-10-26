using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HMB_Client.Helpers;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client
{
    public class Bootstraper
    {
        public Bootstraper()
        {

        }

        public void Run()
        {
            ConfigureDatabaseConnection();
        }

        private void ConfigureDatabaseConnection()
        {
            NHibernateHelper.SessionFactory = CreateSessionFactory();

        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                SQLiteConfiguration.Standard
                .UsingFile("C:\\My\\HomeMedicineBalancer\\Database\\TestDatabase.db")
                )
                //TODO: Configure mapping from approp proj
                .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<Bootstraper>())
                .BuildSessionFactory();
        }
    }
}
