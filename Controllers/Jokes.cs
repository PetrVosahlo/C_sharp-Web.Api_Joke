using Microsoft.AspNetCore.Mvc;
using Web.Api_Joke.Service;

namespace Web.Api_Joke.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class JokesController : ControllerBase {
        private JokesService jokesService;
        public JokesController(JokesDbContext jokesDbContext) {
            this.jokesService = new JokesService(jokesDbContext);
        }
        [HttpGet]
        public List<JokeWithoutPassword> Get() {
            return jokesService.GetAllJokes();
        }
        [HttpGet("{type}")]
        public IActionResult Get(int type) {
            return jokesService.GetFirstJokeOfType(type);
        }
        [HttpGet("{id}, {type}, {next}")]
        public IActionResult Get(int id, int type, bool next) {
            if (!next) {
                return jokesService.GetPreviousJokeOfType(id, type);
            } else {
                return jokesService.GetNextJokeOfType(id, type);
            }
        }
        [HttpPost("{pass}")]
        public IActionResult Post(Joke joke, string pass) {
            return jokesService.PostNewJoke(joke, pass);
        }
        [HttpDelete("{id}, {pass}")]
        public IActionResult Delete(int id, string pass) {
            return jokesService.DeleteJoke(id, pass);
        }
        [HttpPut("{pass}")]
        public IActionResult Put(Joke updatedJoke, string pass) {
            return jokesService.PutJoke(updatedJoke, pass);
        }
    }
}
