using JsonParserInterface;
using WeatherModels;
using WeatherServiceInterfaces;

namespace WeatherServices
{   
    enum DateType 
    {
        Today,
        Tomorrow,
        DayAfterTomorrow
    }

    public class WeatherService : IWeatherService
    {
        private readonly IWeatherDataProviderFactory _factory;
        private readonly IJsonParser _parser;
        public WeatherService(IWeatherDataProviderFactory factory, IJsonParser parser) 
        {
            this._factory = factory;
            this._parser = parser;
        }

        public IDayWeather GetTodayWeather()
        {
            using (var x = _factory.Create()) 
            {                
                dynamic json = _parser.Parse(x.GetWeatherData());
                var w = DataSet(json, DateType.Today);

                return w;
            }
        }

        private static IDayWeather DataSet(dynamic json, DateType dt)
        {
            IDayWeather w = new ADayWeather();

            dynamic aDay = json.forecasts[dt];
            w.DateLabel = aDay.dateLabel;
            w.Date = aDay.date;
            w.Telop = aDay.telop;

            dynamic todayTemperatureMax = aDay.temperature.max;
            if (todayTemperatureMax != null)
            {
                w.TemperatureMax = todayTemperatureMax.celsius + "℃";
            }
            else
            {
                w.TemperatureMax = "---";
            }

            dynamic todayTemperatureMin = aDay.temperature.min;
            if (todayTemperatureMin != null)
            {
                w.TemperatureMin = todayTemperatureMin.celsius + "℃";
            }
            else
            {
                w.TemperatureMin = "---";
            }
            
            dynamic todayImage = aDay.image;
            if (todayImage != null)
            {
                var image = new Image();
                image.Url = todayImage.url;
                image.Width = todayImage.width;
                image.Height = todayImage.height;
                w.Image = image;
            }

            return w;
        }
    }
}
