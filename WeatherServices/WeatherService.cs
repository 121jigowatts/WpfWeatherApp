using JsonParserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherModels;
using WeatherServiceInterfaces;

namespace WeatherServices
{
    public class WeatherService : IWeatherService
    {
        private readonly IJsonParser _parser;
        public WeatherService(IJsonParser parser) 
        {
            this._parser = parser;
        }

        public IDayWeather GetTodayWeather()
        {
            var w = new TodayWeather();

            var req = WebRequest.Create("http://weather.livedoor.com/forecast/webservice/json/v1?city=130010");

            using (var res = req.GetResponse())
            using (var s = res.GetResponseStream())
            {
                dynamic json = _parser.Parse(s);

                //天気(今日)
                dynamic today = json.forecasts[0];
                Console.WriteLine(today.dateLabel + "(" + today.date + ")\t" + today.telop);
                w.DateLabel = today.dateLabel;
                w.Date = today.date;
                w.Telop = today.telop;

                dynamic todayTemperatureMax = today.temperature.max;
                if (todayTemperatureMax != null)
                {
                    Console.WriteLine("最高気温 " + todayTemperatureMax.celsius + "℃");
                    w.TemperatureMax = todayTemperatureMax.celsius + "℃";
                }
                else
                {
                    Console.WriteLine("最高気温 ---");
                    w.TemperatureMax = "---";
                }

                dynamic todayTemperatureMin = today.temperature.min;
                if (todayTemperatureMin != null)
                {
                    Console.WriteLine("最低気温 " + todayTemperatureMin.celsius + "℃");
                    w.TemperatureMin = todayTemperatureMin.celsius + "℃";
                }
                else
                {
                    Console.WriteLine("最低気温 ---");
                    w.TemperatureMin = "---";
                }

                var image = new Image();
                dynamic todayImage = today.image;
                if (todayImage != null) 
                {
                    image.Url = todayImage.url;
                    image.Width = todayImage.width;
                    image.Height = todayImage.height;
                    w.Image = image;
                }


                //天気(明日)
                dynamic tomorrow = json.forecasts[1];
                Console.WriteLine(tomorrow.dateLabel + "(" + tomorrow.date + ")\t" + tomorrow.telop);

                //天気(明後日)
                try
                {
                    dynamic dayAfterTomorrow = json.forecasts[2];
                    Console.WriteLine(dayAfterTomorrow.dateLabel + "(" + dayAfterTomorrow.date + ")\t" + dayAfterTomorrow.telop);
                }
                catch(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
                {
                    //NullObject    
                }
                catch (System.Reflection.TargetInvocationException)
                {
                    //NullObject
                }
                
                Console.WriteLine("\n\n");

                //天気概況文
                Console.WriteLine(json.description.text);
            }

            return w;
            //return new TodayWeather() { 
            //    DateLabel = "A", 
            //    Date = "B", 
            //    Telop = "C", 
            //    TemperatureMax = "D", 
            //    TemperatureMin = "E" 
            //};
        }
    }
}
