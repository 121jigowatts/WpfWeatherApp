using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherModels;

namespace WeatherServiceInterfaces
{
    public interface IWeatherService
    {
        IDayWeather GetTodayWeather();
    }
}
