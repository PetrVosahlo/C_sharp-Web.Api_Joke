using Microsoft.AspNetCore.Mvc;
using Web.Api_Joke.Service;

namespace Web.Api_Joke.Controllers {
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult GetType(int type) {
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
        public IActionResult Post(Joke_General joke, string pass) {
            return jokesService.PostNewJoke(joke, pass);
        }
        [HttpDelete("{id}, {pass}")]
        public IActionResult Delete(int id, string pass) {
            return jokesService.DeleteJoke(id, pass);
        }
        [HttpPut("{pass}")]
        public IActionResult Put(Joke_General updatedJoke, string pass) {
            return jokesService.PutJoke(updatedJoke, pass);
        }
    }
    [Route("[controller]")]
    public class EditController : ControllerBase {
        private JokesService jokesService;
        public EditController(JokesDbContext jokesDbContext) {
            this.jokesService = new JokesService(jokesDbContext);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id) {
            return jokesService.GetJokeOfId(id);
        }
    }
}
