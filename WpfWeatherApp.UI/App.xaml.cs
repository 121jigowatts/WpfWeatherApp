using JsonParser;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WeatherServices;
using WpfWeatherApp.UI.Controllers;

namespace WpfWeatherApp.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WeatherController controller;

        private void OnApplicationStartup(object sender, StartupEventArgs e) 
        {
            var jsonParser = new DynamicJsonPaser();
            var service = new WeatherService(jsonParser);
            controller = new WeatherController(service);
            MainWindow = new MainWindow(controller);
            MainWindow.Show();
            controller.OnLoad();
        }

    }
}
