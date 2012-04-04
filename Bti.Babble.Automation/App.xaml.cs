using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Unity;
using System.Windows.Markup;
using System.Globalization;
using Bti.Babble.Model;

namespace Bti.Babble.Automation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Ensure the current culture passed into bindings 
            // is the OS culture. By default, WPF uses en-US 
            // as the culture, regardless of the system settings.
            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(
                  XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            IUnityContainer container = new UnityContainer();

            container.RegisterType<Model.Entity.BabbleContainer, Model.Entity.BabbleContainer>(new ContainerControlledLifetimeManager())
                .Configure<InjectedMembers>().ConfigureInjectionFor<Model.Entity.BabbleContainer>(new InjectionConstructor());
            container.RegisterType<IBabbleEventRepository, Model.Entity.BabbleEventRepository>(new ContainerControlledLifetimeManager());

            MainWindow window = container.Resolve<MainWindow>();
            window.DataContext = container.Resolve<MainWindowViewModel>();
            window.Show();
        }
    }
}
