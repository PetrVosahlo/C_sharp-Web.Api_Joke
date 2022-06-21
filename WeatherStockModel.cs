namespace Web.Api_Joke {
    public class WeatherStockModel {
        //z vnořených třídy vytvořených na https://json2csharp.com je třeba použít jako datové typy vlastností zastřešující třídy
        public WeatherStockModel() { }
        public WeatherStockModel(int weather_code, double temperature, double wind_speed) {
            this.Current = new Current();
            this.Current.Weather_code = weather_code;
            this.Current.Temperature = temperature;
            this.Current.Wind_speed = wind_speed;
        }
        public Current? Current { get; set; }
        public Location? Location { get; set; }
        public Request? Request { get; set; }
        //public Root? Root { get; set; }
    }
    public class Current {
        //public string observation_time { get; set; }
        public double Temperature { get; set; }
        public int Weather_code { get; set; }
        //public List<string> Weather_icons { get; set; }
        public List <string> Weather_descriptions { get; set; }
        public double Wind_speed { get; set; }
        //public int wind_degree { get; set; }
        //public string wind_dir { get; set; }
        //public int pressure { get; set; }
        //public int precip { get; set; }
        public double humidity { get; set; }
        //public int cloudcover { get; set; }
        //public int feelslike { get; set; }
        //public int uv_index { get; set; }
        //public int visibility { get; set; }
    }

    public class Location {
        public string Name { get; set; }
        public string Country { get; set; }
        //public string region { get; set; }
        //public string lat { get; set; }
        //public string lon { get; set; }
        //public string timezone_id { get; set; }
        //public string localtime { get; set; }
        //public int localtime_epoch { get; set; }
        // public string utc_offset { get; set; }
    }

    public class Request {
        public string Type { get; set; }
        //public string query { get; set; }
        //public string language { get; set; }
        public string Unit { get; set; }
    }

    //public class Root {
    //    public Request request { get; set; }
    //    public Location location { get; set; }
    //    public Current current { get; set; }
    //}
}
