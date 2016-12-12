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
            this.Title = " ";
            this.Temperature = " ";
            this.TempColour = "#FF15F7E8";
            this.Wind = " ";
            this.WindDeg = " ";
            this.Humidity = " ";
            this.Visibility = " ";
            this.RecDate = " ";
            this.Sunrise = " ";
            this.Sunset = " ";
            this.Icon = " ";
        }
    }
}