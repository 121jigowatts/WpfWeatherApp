using System.IO;
using WeatherModels;

namespace WeatherServiceInterfaces
{
    public interface IWeatherService
    {
        IDayWeather GetTodayWeather();
    }

    public interface IWeatherDataProvider
    {
        Stream GetWeatherData();
    }

}
