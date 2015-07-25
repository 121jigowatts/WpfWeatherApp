using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherModels
{
    public interface IDayWeather
    {
        string DateLabel { get; set; }
        string Date { get; set; }
        string Telop { get; set; }
        string TemperatureMax { get; set; }
        string TemperatureMin { get; set; }
        Image Image { get; set; }
    }
}
