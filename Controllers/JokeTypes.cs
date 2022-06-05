using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Api_Joke.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class JokeTypesController : ControllerBase {
        private JokesDbContext _jokesDbContext;
        public JokeTypesController(JokesDbContext jokesDbContext) {
            _jokesDbContext = jokesDbContext;
        }

        [HttpGet]
        public List<JokeType> Get() {
            return _jokesDbContext.jokeTypes.Include(x=> x.TypeJokes).ToList();
        }

        [HttpPost]
        public IActionResult Post(JokeType jokeType) {
            _jokesDbContext.Add(jokeType);
            _jokesDbContext.SaveChanges();
            if (jokeType == null) {
                return NotFound();
            } else {
                return Ok(jokeType);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var jokeType = _jokesDbContext.jokeTypes.FirstOrDefault(j => j.Id == id);
            if (jokeType == null) {
                return NotFound();
            } else {
                return Ok("Zaznam smazan");
            }
        }
    }
}
