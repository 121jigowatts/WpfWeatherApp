using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherModels
{
    public class ADayWeather : IDayWeather
    {
        public string DateLabel { get; set; }
        public string Date { get; set; }
        public string Telop { get; set; }
        public string TemperatureMax { get; set; }
        public string TemperatureMin { get; set; }
        public Image Image { get; set; }
    }
}
