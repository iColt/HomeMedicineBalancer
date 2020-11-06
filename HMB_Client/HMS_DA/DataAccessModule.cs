using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HMB_DA.Interfaces;
using HMB_DA.Repositories;
using NHibernate;
using Unity;

namespace HMS_DA
{
    public class DataAccessModule
    {

        private const string DatabasePath = "C:\\My\\HomeMedicineBalancer\\Database\\TestDatabase.db";

        public void Run(IUnityContainer container)
        {
            RegisterDependencies(container);
        }

        private void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterInstance<ISessionFactory>(CreateSessionFactory());
            container.RegisterType<IMedicineRepository, MedicineRepository>();
        }


        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                SQLiteConfiguration.Standard
                .UsingFile(DatabasePath)
                )
                .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<DataAccessModule>())
                .BuildSessionFactory();
        }
    }
}
