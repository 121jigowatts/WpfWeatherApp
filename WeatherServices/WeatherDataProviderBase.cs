using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherServiceInterfaces;

namespace WeatherServices
{
    public abstract class WeatherDataProviderBase : IWeatherDataProvider, IDisposable
    {
        public WebResponse Response { get; set; }
        public Stream WeatherStream { get; set; }
        public virtual Stream GetWeatherData()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            WeatherStream.Dispose();
            Response.Dispose();
        }
    }
}
