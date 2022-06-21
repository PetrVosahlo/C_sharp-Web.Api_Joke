using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Api_Joke.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private JokesDbContext _jokesDbContext;
        public UsersController(JokesDbContext jokesDbContext) {
            _jokesDbContext = jokesDbContext;
        }

        [HttpGet]
        public List<UserWithoutPassword> Get() {
            var tabJokes = _jokesDbContext.jokes_General; // instance tabulky jokes
            var UserJokesNoPassword = tabJokes.Select(x => new JokeWithoutPassword { // vytvoří nový objekt třídy JokeWithoutPassword
                Id = x.Id,                                  // nalinkování prop třídy Joke na properties třídy JokeWithoutPassword
                Evaluation = x.Evaluation,                  // do jsonu se pošlou všechny prop třídy JokeWithoutPassword
                EvaluationCount = x.EvaluationCount,        // bez nalinkování ChangePassword = ChangePassword = x.ChangePassword
                Content = x.Content,                        // se odešle ChangePassword == null i pokud nová třída je Joke
                UserName = x.UserName,
                JokeTypeId = x.JokeTypeId
            });

            return _jokesDbContext.users.Include(x => x.UserJokes) // připojení záznamů tabulky UserJokes k tabulce User
                .Select(x => new UserWithoutPassword // vytvoří nový objekt třídy UserWithoutPassword
            { // nalinkování properties třídy User na properties třídy UserWithoutPassword do jsonu se pošlou všechny 
                    Name = x.Name, // properties třídy UserWithoutPassword
                    UserJokes = x.UserJokes //bez linku ChangePassword = x.ChangePassword
                }) // se odešle ChangePassword == null i pokud nová třída je User
                .ToList();
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
        [HttpDelete("{us}")]
        public IActionResult Delete(string us) {
            var user = _jokesDbContext.users.FirstOrDefault(x => x.Name == us);
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
