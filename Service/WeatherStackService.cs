using Microsoft.AspNetCore.Mvc;
using Web.Api_Joke.Connector;
using System.Collections;
using Newtonsoft.Json;

namespace Web.Api_Joke.Service {
    public class WeatherStackService : ControllerBase {
        private JokesDbContext _jokesDbContext;
        string town = "Praha";
        WeatherstackConnector weatherstackConnector;
        public WeatherStackService(JokesDbContext jokesDbContext) {
            _jokesDbContext = jokesDbContext;
        }

        public async Task<IActionResult> GetJokeForWeather(string town, string country) {
            WeatherStockModel actualWeather = new WeatherStockModel();
            Joke_Weather jokeWeather = new Joke_Weather();
            WeatherStockResult result = null;
            weatherstackConnector = new WeatherstackConnector(town, country);
            bool responseOK = await weatherstackConnector.GetWeatherForCityAsync();
            if (responseOK == true) { //weatherstackConnector.WeatherstackModel.Current.Weather_code>0
                actualWeather = weatherstackConnector.WeatherstackModel;
                jokeWeather = pickJoke(actualWeather, 1, true);
                if (jokeWeather != null) {
                    result = new(actualWeather, jokeWeather);
                    return Ok(JsonConvert.SerializeObject(result));
                } else {
                    return BadRequest();
                }
            } else {
                return NotFound();
            }
        }
        public IActionResult GetJokeForWeatherPreviousNext(int weather_code, double temperature, double wind_speed, int jokeId, bool next) {
            WeatherStockModel actualWeather = new WeatherStockModel(weather_code, temperature, wind_speed);
            Joke_Weather jokeWeather = new Joke_Weather();
            jokeWeather = pickJoke(actualWeather, jokeId, next);
            if (jokeWeather != null) {
                return Ok(JsonConvert.SerializeObject(jokeWeather));
            } else {
                return NotFound();
            }
        }

        public IActionResult TestJokeForWeather(int weather_code, double temperature, double wind_speed, int jokeId, bool next) {
            WeatherStockModel actualWeather = new WeatherStockModel(weather_code, temperature, wind_speed);
            Joke_Weather jokeWeather = new Joke_Weather();
            WeatherStockResult result = null;
            jokeWeather = pickJoke(actualWeather, jokeId, next);
            if (jokeWeather != null) {
                result = new WeatherStockResult(weather_code, temperature, wind_speed, jokeWeather);
                return Ok(JsonConvert.SerializeObject(result));
            } else {
                return NotFound();
            }
        }

        public Joke_Weather pickJoke(WeatherStockModel actualWeather, int jokeId, bool next) {
            string weatherType = getWeatherType(actualWeather.Current.Weather_code);
            if (!weatherType.Equals("new")) {
                string temperatureType = getTemperature(actualWeather.Current.Temperature);
                string windType = getWindType(actualWeather.Current.Wind_speed);
                string seasoneType = getSeason();
                var jokeWeatherType = _jokesDbContext.jokes_Weather.Where(x => x.WeatherType.Contains(weatherType) || x.WeatherType.Equals("Type"));
                var jokeTemperature = jokeWeatherType.Where(x => x.Temperature.Equals(temperatureType) || x.Temperature.Equals("Tem"));
                var jokeWindSpeed = jokeTemperature.Where(x => x.WindSpeed.Contains(windType) || x.WindSpeed.Equals("Wind"));
                var jokeSeason = jokeWindSpeed.Where(x => x.Season.Contains(seasoneType) || x.Season.Equals("Seas"));
                if (next && jokeSeason.Count() > 0) {
                    if (jokeSeason.OrderBy(x => x.Id).Last().Id > jokeId) {
                        return jokeSeason.Where(x => x.Id > jokeId).OrderBy(x => x.Id).FirstOrDefault();
                    } else {
                        return jokeSeason.OrderBy(x => x.Id).First();
                    }
                } else if (!next && jokeSeason.Count() > 0) {
                    if (jokeSeason.OrderBy(x => x.Id).First().Id < jokeId) {
                        return jokeSeason.Where(x => x.Id < jokeId).OrderBy(x => x.Id).LastOrDefault();
                    } else {
                        return jokeSeason.OrderBy(x => x.Id).Last();
                    }
                } else {
                    return null;
                }
            } else {
                return null;
            }
        }
        private string getWeatherType(int weatherCode) {
            switch (weatherCode) {
                case 143:
                case 113:
                case 116: return "Sunny";
                case 176:
                case 185:
                case 263:
                case 266:
                case 281:
                case 293:
                case 296:
                case 299:
                case 302:
                case 311:
                case 314:
                case 356:
                case 353:
                case 350:
                case 374:
                case 377: return "Rain";
                case 179:
                case 182:
                case 317:
                case 320:
                case 323:
                case 326:
                case 329:
                case 332:
                case 335:
                case 362:
                case 365:
                case 368:
                case 371: return "Snow";
                case 119:
                case 122: return "Clouds";
                case 200:
                case 386:
                case 389:
                case 392:
                case 395: return "Storm";
                case 248:
                case 260: return "Fog";
                case 305:
                case 308:
                case 359: return "strongRa";
                case 227:
                case 230:
                case 284:
                case 338: return "strongSn";
                default: return "new";
            }
        }
        private string getTemperature(double temperature) {
            if (temperature > 0) {
                return "above";
            } else {
                return "bellow";
            }
        }
        private string getWindType(double windSpeed) {
            if (windSpeed < 40) {
                return "Wind";
            } else if (windSpeed < 55) {
                return "strong";
            } else if (windSpeed >= 55) {
                return "veryStr";
            } else {
                return "error";
            }
        }
        private string getSeason() {
            DateTime today = DateTime.Now;
            switch (today.Month) {
                case int month when month < 4: return "winter";
                case int month when month < 7: return "spring";
                case int month when month < 10: return "summer";
                case int month when month < 12: return "autumn";
                case int month when month == 12: return "winter";
                default: return "error";
            }
        }
    }
}
