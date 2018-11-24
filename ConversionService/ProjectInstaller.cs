using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
namespace KMA.APZRPMJ2018.NumberConverter.ConversionService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private void InitializeComponent()
        {
            _serviceProcessInstaller = new ServiceProcessInstaller();
            _serviceInstaller = new ServiceInstaller();
            _serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            _serviceProcessInstaller.Password = null;
            _serviceProcessInstaller.Username = null;
            _serviceInstaller.ServiceName = NumberConverterWindowsService.CurrentServiceName;
            _serviceInstaller.DisplayName = NumberConverterWindowsService.CurrentServiceDisplayName;
            _serviceInstaller.Description = NumberConverterWindowsService.CurrentServiceDescription;
            _serviceInstaller.StartType = ServiceStartMode.Automatic;
            Installers.AddRange(new Installer[]
            {
                _serviceProcessInstaller,
                _serviceInstaller
            });
        }
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        private ServiceProcessInstaller _serviceProcessInstaller;
        private ServiceInstaller _serviceInstaller;
    }
}