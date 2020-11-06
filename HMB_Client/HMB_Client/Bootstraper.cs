using Unity;
using HMB_Client.Services;
using HMB_Client.Interfaces;
using HMS_DA;

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
        }


        private void RegisterDependencies()
        {
            UnityContainer.RegisterType<MainViewModel>();
            UnityContainer.RegisterType<IMedicineService, MedicineService>();

        }
    }
}
