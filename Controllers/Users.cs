using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api_Joke.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private JokesDbContext _jokesDbContext;
        public UsersController(JokesDbContext jokesDbContext) {
            _jokesDbContext = jokesDbContext;
        }

        [HttpGet]
        public List<User> Get() {
            return _jokesDbContext.users.ToList();
        }
        [HttpPost()]
        public IActionResult Post(User us) {
            var user = _jokesDbContext.users.Add(us);
            _jokesDbContext.SaveChanges();
            if (user != null) {
                return Ok(us);
            } else {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var user = _jokesDbContext.users.FirstOrDefault(x => x.id == id);
            if (user != null) {
                _jokesDbContext.users.Remove(user);
                _jokesDbContext.SaveChanges();
                return Ok("Zmazan uzivatel:");
            } else {
                return NotFound();
            }
        }
    }
}
