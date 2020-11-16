using Unity;
using HMB_Client.Services;
using HMB_Client.Interfaces;
using HMS_DA;
using Unity.Lifetime;
using System;

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
            RegisterDependencies();
            container = UnityContainer;
            new DataAccessModule().Run(container);
            //TODO: When some framework will be added, we need to move it somewhere else
            LoadCache();
        }

        private void LoadCache()
        {
            var cacheService = UnityContainer.Resolve<ICacheService>();
            cacheService.Load();
        }

        private void RegisterDependencies()
        {
            UnityContainer.RegisterType<MainViewModel>();
            UnityContainer.RegisterType<ICacheService, CacheService>((ITypeLifetimeManager)InstanceLifetime.Singleton);
            UnityContainer.RegisterType<IMedicineService, MedicineService>();
            UnityContainer.RegisterType<IMedicineTypeService, MedicineTypeService>();

        }
    }
}
