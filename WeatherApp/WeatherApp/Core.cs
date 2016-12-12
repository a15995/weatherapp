using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
        static string key = "YOUR API KEY HERE";
        static double lon = 12.45103; // var lon = (string)results["coord"]["lon"];
        static double lat = 55.79488; // var lat = (string)results["coord"]["lat"];
        public static async Task<Weather> GetWeather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid

            string queryString = "http://api.openweathermap.org/data/2.5/weather?q="
                + zipCode + "&units=metric&appid=" + key;

            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false); // GET-datakald - se DataService.cs - JSON-objekt retur

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Icon = "imp" + (string)results["weather"][0]["icon"] + ".png";
                weather.Title = (string)results["name"];
                weather.Temperature = Math.Round((double)results["main"]["temp"]) + "°C";
                var tempcolour = Convert.ToInt32(127 + ((Math.Round((double)results["main"]["temp"])) * 3));
                if (tempcolour > 255)
                {
                    tempcolour = 255;
                }
                else if (tempcolour < 0)
                {
                    tempcolour = 0;
                }
                weather.TempColour = "#FF15F7" + tempcolour.ToString("X");
                weather.Wind = Math.Round((double)results["wind"]["speed"]) + "";
                weather.WindDeg = (string)results["wind"]["deg"];
                weather.Humidity = (string)results["main"]["humidity"] + "%";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime recdate = time.AddSeconds((double)results["dt"]).ToLocalTime();
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.RecDate = recdate.ToString("dddd, d. MMMM", new CultureInfo("da"));
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";



                return weather; // Parset og sat ind i weather-objekt
            }
            else
            {
                return null;
            }
        }

        public static async Task<Forecast> GetForecast(string zipCode)
        {
            string queryString = "api.openweathermap.org/data/2.5/forecast?q="
                + zipCode + "&units=metric&appid=" + key;

            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false); // GET-datakald - se DataService.cs - JSON-objekt retur

            if (results["forecast"] != null)
            {
                Forecast forecast = new Forecast();

                return forecast; // Parset og sat ind i forecast-objekt
            }
            else
            {
                return null;
            }
        }

        public static async Task<UV> GetUV(string zipCode)
        {
            string queryString = "http://api.owm.io/air/1.0/uvi/current?lat=" + lat + "&lon="
                + lon + "&appid=" + key;

            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false); // GET-datakald - se DataService.cs - JSON-objekt retur

            if (results["current"] != null)
            {
                UV uv = new UV();
                var uvalue = (double)results["value"];
                if (uvalue < 3)
                {
                    uv.UVIcon = "lowl.png";
                }
                else if (uvalue < 6)
                {
                    uv.UVIcon = "moderatem.png";
                }
                else if (uvalue < 8)
                {
                    uv.UVIcon = "highh.png";
                }
                else if (uvalue < 11)
                {
                    uv.UVIcon = "vhighv.png";
                }
                else
                {
                    uv.UVIcon = "extremex.png";
                }

                return uv; // Parset og sat ind i uv-objekt
            }
            else
            {
                return null;
            }
        }
    }
}