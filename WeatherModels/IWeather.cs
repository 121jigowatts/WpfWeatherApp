using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherModels
{
    public interface IWeather
    {
        IList<IDayWeather> DayWeatherList { get; set; }
        string Description { get; set; }
    }
}
