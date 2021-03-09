using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HMB_DA.Mappers;
using HMB_Domain.BusinessObjects;
using HMB_DA.DomainFactories;
using HMB_DA.Interfaces;
using HMB_DA.Mappers;
using NHibernate;
using Unity;

namespace HMB_DA
{
    public class DataAccessModule
    {
        //TODO: config service(low priority)
        private const string DatabasePath = "..\\..\\..\\..\\..\\Database\\TestDatabase.db";

        public void Run(IUnityContainer container)
        {
            RegisterDependencies(container);
        }

        private void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterInstance<ISessionFactory>(CreateSessionFactory());
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


        //TIP: Why to use approach with manually adding of Map configurations( .Mappings(m => ConfigureMapping(m))) instead of more convinient and simplier:
        // .Mappings(m => m.FluentMappings.AddFromAssemblyOf<>
        //Answer: to configure subclass-class mapping(ObjectMap<Medicine>)
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
