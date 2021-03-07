using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HMB_DA.Domain;
using HMB_DA.Mappers;
using HMS_DA.Domain;
using HMS_DA.DomainFactories;
using HMS_DA.Interfaces;
using HMS_DA.Mappers;
using NHibernate;
using Unity;

namespace HMS_DA
{
    public class DataAccessModule
    {
        //TODO: config service(low priority)
        private const string DatabasePath = "C:\\My\\HomeMedicineBalancer\\Database\\TestDatabase.db";

        public void Run(IUnityContainer container)
        {
            RegisterDependencies(container);
        }

        private void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterInstance<ISessionFactory>(CreateSessionFactory());
            //container.RegisterType<IMedicineRepository, MedicineRepository>();
            //container.RegisterType<IMedicineTypeRepository, MedicineTypeRepository>();
            container.RegisterType<IDomainObjectFactory<Medicine>, MedicineFactory>();
            container.RegisterType<IDomainObjectFactory<MedicineType>, MedicineTypeFactory>();

            container.RegisterType<IDomainObjectFactory<MedicineCollection>, MedicineCollectionFactory>();
            container.RegisterType<IDomainObjectFactory<MedicineTypeCollection>, MedicineTypeCollectionFactory>();
        }

        private static void ConfigureMapping(MappingConfiguration configuration)
        {

            configuration.FluentMappings.Add(typeof(MedicineTypeMap));
            configuration.FluentMappings.Add(typeof(MedicineMap));
            configuration.FluentMappings.Add(typeof(EntityMap));
            configuration.FluentMappings.Add(typeof(ObjectMap<Medicine>));
        }



        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                SQLiteConfiguration.Standard
                .UsingFile(DatabasePath)
                )
                .Mappings(m => ConfigureMapping(m))
                .BuildSessionFactory();
        }
    }
}
