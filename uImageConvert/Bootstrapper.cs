using Microsoft.Practices.Unity;
using Prism.Unity;
using uImageConvert.Views;
using System.Windows;

namespace uImageConvert
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();  
            Container.RegisterTypeForNavigation<ConverterView>("converter");
            Container.RegisterTypeForNavigation< AboutView>("about");
            Container.RegisterTypeForNavigation< SettingsView>("setting");
            
        }
    }
}
