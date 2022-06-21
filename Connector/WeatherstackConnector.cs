using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Web.Api_Joke.Connector {
    public class WeatherstackConnector {
        string[] ApiKey = { "7c59826e1ba26567a6e63c11e56d359e",
            "94268f5e28fd9d2785e59ff6eb1b24a2",
            "12241992c5cb2bda518cef01b39da9dd" };
        
        string town;
        string country;
        WeatherStockModel weatherstackModel;
        public WeatherStockModel WeatherstackModel { get => weatherstackModel; set => weatherstackModel = value; }
        public WeatherstackConnector(string town, string country) {
            this.town = town;
            this.country = country;
            this.weatherstackModel = new WeatherStockModel();
        }
        public async Task<bool> GetWeatherForCityAsync() {           
            using (var client = new HttpClient()) {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                int i = 0;
                int numericStatusCode = 101;
                while (numericStatusCode >=101&& numericStatusCode <= 104 && i < 3) {
                    string url = $"http://api.weatherstack.com/current?access_key={ApiKey[i]}&query={town},{country}";
                    response = client.GetAsync(url).Result; // Result způsobí synchronní volání
                    numericStatusCode = (int)response.StatusCode;
                    i++;
                }
                if (response.IsSuccessStatusCode) {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result; // Result zppůsobí synchronní volání
                    weatherstackModel = JsonConvert.DeserializeObject<WeatherStockModel>(responseString);
                    return true;
                } else {
                    return false;
                }
            }
        }
        //public void PokusGetWeatherForCityAsync() {
        //    var content = "{\"request\":{\"type\":\"City\",\"query\":\"Praha, USA United States of America\"," +
        //    "\"language\":\"en\",\"unit\":\"m\"},\"location\":{\"name\":\"Praha\"," +
        //    "\"country\":\"USA United States of America\",\"region\":\"Texas\",\"lat\":\"29.687\"," +
        //    "\"lon\":\"-97.108\",\"timezone_id\":\"America\\/Chicago\",\"localtime\":\"2022-06-11 15:17\"," +
        //    "\"localtime_epoch\":1654960620,\"utc_offset\":\"-5.0\"},\"current\":{\"observation_time\":\"08:17 PM\"," +
        //    "\"temperature\":38.4,\"weather_code\":266," +
        //    "\"weather_icons\":[\"https:\\/\\/assets.weatherstack.com\\/images\\/wsymbols01_png_64\\/wsymbol_0001_sunny.png\"]," +
        //    "\"weather_descriptions\":[\"Sunny\"],\"wind_speed\":16.3,\"wind_degree\":190,\"wind_dir\":\"S\"," +
        //    "\"pressure\":1010,\"precip\":0,\"humidity\":45.2,\"cloudcover\":0,\"feelslike\":38,\"uv_index\":10," +
        //    "\"visibility\":16,\"is_day\":\"yes\"}}";
        //    WeatherstackModel = JsonConvert.DeserializeObject<WeatherStockModel>(content);
        //}
    }
}
