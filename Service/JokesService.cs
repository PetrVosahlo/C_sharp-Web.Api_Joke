using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Api_Joke.Service {
    public class JokesService : ControllerBase {
        private JokesDbContext _jokesDbContext; // instance třídy definující databázi - umožňuje přístup k databázi
        public JokesService(JokesDbContext jokesDbContext) { // konstruktor pomocí dependenci injection vloží jako parametr objekt umoňující práci s databází
            _jokesDbContext = jokesDbContext;
        }

        public List<JokeWithoutPassword> GetAllJokes() { // výpis všech vtipů
            var res = _jokesDbContext.jokes.Select(x => new JokeWithoutPassword { // vytvoří nový objekt třídy JokeWithoutPassword
                Id = x.Id,                                  // nalinkování prop třídy Joke na properties třídy JokeWithoutPassword
                Evaluation = x.Evaluation,                  // do jsonu se pošlou všechny prop třídy JokeWithoutPassword
                EvaluationCount = x.EvaluationCount,        // bez nalinkování ChangePassword = ChangePassword = x.ChangePassword
                Content = x.Content,                        // se odešle ChangePassword == null i pokud nová třída je Joke
                UserName = x.UserName,
                JokeTypeId = x.JokeTypeId,
                Temperature = x.Temperature,
                SunRain = x.SunRain,
                Wind = x.Wind,
                Snow = x.Snow,
                Season = x.Season
            }).ToList();
            return res;
        }
        public IActionResult GetFirstJokeOfType(int type) { // první vtip s JokeTypeId == type
            var joke = _jokesDbContext.jokes.Select(x => new JokeWithoutPassword { // vytvoří nový objekt třídy JokeWithoutPassword
                Id = x.Id,                              // nalinkování prop třídy Joke na properties třídy JokeWithoutPassword
                Evaluation = x.Evaluation,              // do jsonu se pošlou všechny prop třídy JokeWithoutPassword
                EvaluationCount = x.EvaluationCount,    // bez nalinkování ChangePassword = ChangePassword = x.ChangePassword
                Content = x.Content,                    // se odešle ChangePassword == null i pokud nová třída je Joke
                UserName = x.UserName,
                JokeTypeId = x.JokeTypeId,
                Temperature = x.Temperature,
                SunRain = x.SunRain,
                Wind = x.Wind,
                Snow = x.Snow,
                Season = x.Season
            }).FirstOrDefault(x => x.JokeTypeId == type);
            if (joke == null) {
                return NotFound();
            } else {
                return Ok(joke);
            }
        }
        public IActionResult GetNextJokeOfType(int id, int type) { // vrátí následující vtip daného typu
            var joke = _jokesDbContext.jokes.Select(x => new Joke { // vytvoří nový objekt třídy Joke
                Id = x.Id,                              // nalinkování prop třídy Joke na properties nové třídy Joke
                Evaluation = x.Evaluation,              // do jsonu se pošlou všechny prop třídy JokeWithoutPassword
                EvaluationCount = x.EvaluationCount,    // bez nalinkování ChangePassword = ChangePassword = x.ChangePassword
                Content = x.Content,                    // se odešle ChangePassword == null i pokud nová třída je Joke
                UserName = x.UserName,
                JokeTypeId = x.JokeTypeId,
                Temperature = x.Temperature,
                SunRain = x.SunRain,
                Wind = x.Wind,
                Snow = x.Snow,
                Season = x.Season
            }).Where(x => x.JokeTypeId == type).FirstOrDefault(x => x.Id == id);
            if (joke == null) { // kontrola existence vtipu s daným id a typem
                return GetFirstJokeOfType(type); // první vtip s JokeTypeId == type
            } else {
                if (_jokesDbContext.jokes.Where(x => x.JokeTypeId == type).OrderBy(x => x.Id).Last() != joke) { // kontrola že vtip není poslední daného typu
                    var nextJoke = _jokesDbContext.jokes.Where(x => x.JokeTypeId == type).Where(x => x.Id > id).OrderBy(x => x.Id).First(); // vyhledání následujícího vtipu
                    return Ok(nextJoke);
                } else {
                    return GetFirstJokeOfType(type); // první vtip s JokeTypeId == type
                }
            }
        }

        public IActionResult GetPreviousJokeOfType(int id, int type) { // vrátí předchozí vtip daného typu
            var joke = _jokesDbContext.jokes.Select(x => new Joke { // vytvoří nový objekt třídy Joke
                Id = x.Id,                                  // nalinkování prop třídy Joke na properties nové třídy Joke
                Evaluation = x.Evaluation,                  // do jsonu se pošlou všechny prop třídy JokeWithoutPassword
                EvaluationCount = x.EvaluationCount,        // bez nalinkování ChangePassword = ChangePassword = x.ChangePassword
                Content = x.Content,                        // se odešle ChangePassword == null i pokud nová třída je Joke
                UserName = x.UserName,
                JokeTypeId = x.JokeTypeId,
                Temperature = x.Temperature,
                SunRain = x.SunRain,
                Wind = x.Wind,
                Snow = x.Snow,
                Season = x.Season
            }).Where(x => x.JokeTypeId == type).FirstOrDefault(x => x.Id == id);
            if (joke == null) { // kontrola existence vtipu s daným id a typem
                return GetFirstJokeOfType(type); // první vtip s JokeTypeId == type
            } else {
                if (_jokesDbContext.jokes.Where(x => x.JokeTypeId == type).First() != joke) { // kontrola že vtip není první daného typu
                    var prevJoke = _jokesDbContext.jokes.Where(x => x.JokeTypeId == type).OrderBy(x => x.Id).Where(x => x.Id < id).Last(); // vyhledání předchozího vtipu
                    return Ok(prevJoke);
                } else {
                    var prevJoke = _jokesDbContext.jokes.Where(x => x.JokeTypeId == type).OrderBy(x => x.Id).Last();// poslední vtip s JokeTypeId == type
                    return Ok(prevJoke);
                }
            }
        }

        public IActionResult PostNewJoke(Joke joke, string pass) { // vložení nového vtipu
            var Upass = _jokesDbContext.users.Where(x => x.Name.Equals(joke.UserName)).First().Password;

            if (Upass.Equals(pass)) {
                _jokesDbContext.jokes.Add(joke);
                _jokesDbContext.SaveChanges();
                if (joke == null) {
                    return NotFound();
                } else {
                    return Ok(joke);
                }
            } else {
                return Unauthorized();
            }
        }

        public IActionResult DeleteJoke(int id, string pass) { // vymazání vtipu
            string userJoke = _jokesDbContext.jokes.Where(x => x.Id == id).First().UserName;
            if (userJoke == null) { // kontrola existence vtipu s daným id a typem
                return NotFound();
            } else {
                string Upass = _jokesDbContext.users.Where(x => x.Name.Equals(userJoke)).First().Password;
                if (Upass.Equals(pass)) {
                    var joke = _jokesDbContext.jokes.FirstOrDefault(x => x.Id == id);
                    _jokesDbContext.jokes.Remove(joke);
                    _jokesDbContext.SaveChanges();
                    return Ok(joke);
                } else {
                    return Unauthorized();
                }
            }
        }

        public IActionResult PutJoke(Joke updatedJoke, string pass) { // oprava vtipu
            var joke = _jokesDbContext.jokes.FirstOrDefault(x => x.Id == updatedJoke.Id);
            if (joke == null) { // kontrola existence vtipu s daným id a typem
                return NotFound();
            } else {
                string Upass = _jokesDbContext.users.Where(x => x.Name.Equals(joke.UserName)).First().Password;
                if (Upass.Equals(pass)) {
                    joke.Evaluation = updatedJoke.Evaluation;
                    joke.EvaluationCount = updatedJoke.EvaluationCount;
                    joke.Content = updatedJoke.Content;
                    _jokesDbContext.SaveChanges();
                    return Ok(joke);
                } else {
                    return Unauthorized();
                }
            }
        }
    }
}
