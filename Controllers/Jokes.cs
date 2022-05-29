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
        public List<Joke> Get() {
            return jokesService.GetAll();
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
        [HttpPost]
        public IActionResult Post(Joke joke) {
            return jokesService.PostNewJoke(joke);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return jokesService.DeleteJoke(id);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Joke updatedJoke) {
            return jokesService.PutJoke(id, updatedJoke);
        }
    }
}
