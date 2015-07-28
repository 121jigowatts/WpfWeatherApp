using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherServices
{
    public interface IWeatherDataProviderFactory
    {
        WeatherDataProviderBase Create();
    }

    public class LWWSProviderFactory : IWeatherDataProviderFactory
    {
        public WeatherDataProviderBase Create()
        {
            return new LWWSProvider();
        }
    }
}
