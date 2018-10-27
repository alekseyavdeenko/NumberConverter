using System.Windows;
using KMA.APZRPMJ2018.NumberConverter.Managers;

namespace NumberConverter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            StationManager.Initialize();
        }
    }
}
