namespace WeatherApp
{
    public class Weather // Properties
    {
        public string Title { get; set; }
        public string Temperature { get; set; }
        public string TempColour { get; set; }
        public string Wind { get; set; }
        public string WindDeg { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string RecDate { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Icon { get; set; }

        public Weather() // Constructor
        {
            //Because labels bind to these values, set them to an empty string to
            //ensure that the label appears on all platforms by default.
            this.Title = "N/A";
            this.Temperature = "N/A";
            this.TempColour = "#FF15F7E8";
            this.Wind = "N/A";
            this.WindDeg = "0";
            this.Humidity = "N/A";
            this.Visibility = "N/A";
            this.RecDate = "N/A";
            this.Sunrise = "N/A";
            this.Sunset = "N/A";
            this.Icon = "na.png";
        }
    }
    public class Forecast // Properties
    {
        public string Title { get; set; }
        public string Temperature { get; set; }
        public string TempColour { get; set; }
        public string Wind { get; set; }
        public string WindDeg { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string RecDate { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Icon { get; set; }

        public Forecast() // Constructor
        {
            //Because labels bind to these values, set them to an empty string to
            //ensure that the label appears on all platforms by default.
            this.Title = "N/A";
            this.Temperature = "N/A";
            this.TempColour = "#FF15F7E8";
            this.Wind = "N/A";
            this.WindDeg = "0";
            this.Humidity = "N/A";
            this.Visibility = "N/A";
            this.RecDate = "N/A";
            this.Sunrise = "N/A";
            this.Sunset = "N/A";
            this.Icon = "na.png";
        }
    }
    public class UV // Properties
    {
        public string UVIcon { get; set; }

        public UV() // Constructor
        {
            //Because labels bind to these values, set them to an empty string to
            //ensure that the label appears on all platforms by default.
            this.UVIcon = "nauv.png";
        }
    }
}