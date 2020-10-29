using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HMB_Client.Helpers;
using NHibernate;
using Unity;
using System;
using System.Collections.Generic;
using System.Text;
using HMB_Client.Services;
using HMB_Client.Repositories;
using HMB_Client.Interfaces;

namespace HMB_Client
{
    public class Bootstraper
    {
        private const string DatabasePath = "C:\\My\\HomeMedicineBalancer\\Database\\TestDatabase.db";
        public IUnityContainer UnityContainer { get; set; }

        public Bootstraper()
        {

        }

        public void Run(out IUnityContainer container)
        {
            UnityContainer = new UnityContainer();
            RegisterDependencies();
            container = UnityContainer;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                SQLiteConfiguration.Standard
                .UsingFile(DatabasePath)
                )
                //TODO: Configure mapping from approp proj
                .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<Bootstraper>())
                .BuildSessionFactory();
        }

        private void RegisterDependencies()
        {
            UnityContainer.RegisterInstance<ISessionFactory>(CreateSessionFactory());
            UnityContainer.RegisterType<IObjectRepository, ObjectRepository>();
            UnityContainer.RegisterType<MainViewModel>();
            UnityContainer.RegisterType<IMedicineService, MedicineService>();

        }
    }
}
