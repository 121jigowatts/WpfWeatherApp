using System.IO;
using System.Net;

namespace WeatherServices
{
    public class LWWSProvider : WeatherDataProviderBase
    {
        public override Stream GetWeatherData()
        {
            var req = WebRequest.Create("http://weather.livedoor.com/forecast/webservice/json/v1?city=130010");

            Response = req.GetResponse();
            WeatherStream = Response.GetResponseStream();

            return WeatherStream;
        }
    }
}
