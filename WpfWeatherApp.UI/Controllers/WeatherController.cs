using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherServiceInterfaces;
using WpfWeatherApp.UI.ViewModels;

namespace WpfWeatherApp.UI.Controllers
{
    public class WeatherController : INotifyPropertyChanged
    {       
        private readonly IWeatherService _service;
        private TodayWeatherViewModel _model;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public WeatherController(IWeatherService service)
        {
            this._service = service;
        }

        public void OnLoad()
        {
            var data = _service.GetTodayWeather();

            TodayWeatherModel = new TodayWeatherViewModel()
            {
                DateLabel = data.DateLabel,
                Date = data.Date,
                Telop = data.Telop,
                TemperatureMax = data.TemperatureMax,
                TemperatureMin = data.TemperatureMin,
                Image = data.Image
            };
        }

        public TodayWeatherViewModel TodayWeatherModel
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TodayWeatherModel"));
            }
        }
    }
}
