using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Practices.Unity;
using Bti.Babble.Traffic.Model;

namespace Bti.Babble.Traffic
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

            container.RegisterType<ITrafficLogRepository, Model.Entity.TrafficLogRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITrafficItemRepository, Model.Entity.TrafficItemRepository>(new ContainerControlledLifetimeManager());

            MainWindow window = container.Resolve<MainWindow>();
            window.DataContext = container.Resolve<TrafficLogViewModel>();
            window.Show();
        }
    }
}
