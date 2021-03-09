using Unity;
using HMB_Client.Services;
using HMB_Client.Interfaces;
using HMS_DA;
using Unity.Lifetime;
using AutoMapper;
using CommonServiceLocator;
using Unity.ServiceLocation;

namespace HMB_Client
{
    public class Bootstraper
    {
        public IUnityContainer UnityContainer { get; set; }

        public Bootstraper()
        {

        }

        public void Run(out IUnityContainer container)
        {
            UnityContainer = new UnityContainer();
            RegisterContainer(UnityContainer);
            RegisterDependencies();
            RegisterMappings();
            container = UnityContainer;
            //The only call that holds reference to DAL proj
            new DataAccessModule().Run(container);
            //TODO: When some framework will be added, we need to move it somewhere else
            LoadCache();
        }

        private void LoadCache()
        {
            var cacheService = UnityContainer.Resolve<ICacheService>();
            cacheService.Load();
        }

        public void RegisterContainer(IUnityContainer container)
        {
            var locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }


        private void RegisterDependencies()
        {
            UnityContainer.RegisterType<MainViewModel>();
            UnityContainer.RegisterType<ICacheService, CacheService>((ITypeLifetimeManager)InstanceLifetime.Singleton);
            UnityContainer.RegisterType<IMedicineService, MedicineService>();
            UnityContainer.RegisterType<IMedicineTypeService, MedicineTypeService>();

        }

        private void RegisterMappings()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddMaps(nameof(HMB_Client));
            });
            UnityContainer.RegisterInstance<IMapper>(config.CreateMapper());
        }
    }
}
