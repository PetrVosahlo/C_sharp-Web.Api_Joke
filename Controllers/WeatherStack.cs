using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api_Joke.Service;

namespace Web.Api_Joke.Controllers {
    [ApiController]
    [Route("weather/[controller]")]
    public class WeatherStackController : ControllerBase {
        internal WeatherStackService weatherStackService;
        public WeatherStackController(JokesDbContext jokesDbContext) {
            this.weatherStackService = new WeatherStackService(jokesDbContext);
        }
        [HttpGet("{town},{country}")]
        public async Task<IActionResult> GetWeather(string town, string country) {
            return await weatherStackService.GetJokeForWeather(town, country);
        }
 
    }
    [Route("weather/[controller]")]
    public class WeatherStackPreviousNextController : ControllerBase {
        internal WeatherStackService weatherStackService;
        public WeatherStackPreviousNextController(JokesDbContext jokesDbContext) {
            this.weatherStackService = new WeatherStackService(jokesDbContext);
        }
        [HttpGet("{weather_code}, {temperature},{wind_speed},{jokeId},{next}")]
        public IActionResult GetWeatherPreviousNext(int weather_code, double temperature, double wind_speed, int jokeId, bool next) {
            return weatherStackService.GetJokeForWeatherPreviousNext(weather_code, temperature, wind_speed, jokeId, next);
        }
    }
    [Route("weather/[controller]")]
    public class WeatherTestController : ControllerBase {
        internal WeatherStackService weatherStackService;
        public WeatherTestController(JokesDbContext jokesDbContext) {
            this.weatherStackService = new WeatherStackService(jokesDbContext);
        }
        [HttpGet("{weather_code}")]
        public IActionResult GetWeatherPreviousNext(int weather_code) {
            return weatherStackService.TestJokeForWeather(weather_code, 38, 25, 1, true);
        }
    }
}