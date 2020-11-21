using System.Windows;
using Unity;

namespace HMB_Client
{
    public partial class MainWindow : Window
    {
        //TODO: Move unity registrations to start point of app
        public MainWindow()
        {
            InitializeComponent();
            new Bootstraper().Run(out var unityContainer);
            var vm = unityContainer.Resolve<MainViewModel>();
            vm.Initialize();
            DataContext = vm;
        }

  
    }
}
