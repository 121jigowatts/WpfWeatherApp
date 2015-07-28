using JsonParser;
using JsonParserInterface;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WeatherServiceInterfaces;
using WeatherServices;
using WpfWeatherApp.UI.Controllers;

namespace WpfWeatherApp.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private WeatherController controller;
        
        private void OnApplicationStartup(object sender, StartupEventArgs e) 
        {
            var c = new UnityContainer();
            c.RegisterType<IJsonParser, DynamicJsonPaser>();
            c.RegisterType<IWeatherDataProviderFactory, LWWSProviderFactory>();
            c.RegisterType<IWeatherService, WeatherService>();
            c.RegisterType<WeatherController>();
            c.RegisterType<MainWindow>();

            MainWindow = c.Resolve<MainWindow>();
            MainWindow.Show();
            
            ((WeatherController)MainWindow.DataContext).OnLoad();
        }

    }
}
