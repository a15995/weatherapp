using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid
            string key = "API key";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q="
                + zipCode + "&units=metric&appid=" + key;

            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false); // GET-datakald - se DataService.cs - JSON-objekt retur

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Icon = "imp" + (string)results["weather"][0]["icon"] + ".png";
                weather.Title = (string)results["name"];
                weather.Temperature = Math.Round((double)results["main"]["temp"]) + "°C";
                double dec = 127 + ((Math.Round((double)results["main"]["temp"])) * 30);
                string hex = dec.ToString("X2");
                Debug.WriteLine("#FF15F7" + hex);
                weather.TempColour = "#FF15F7" + hex;
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
    }
}