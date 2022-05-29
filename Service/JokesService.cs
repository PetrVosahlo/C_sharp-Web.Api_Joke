using Microsoft.AspNetCore.Mvc;
namespace Web.Api_Joke.Service {
    public class JokesService : ControllerBase {
        private JokesDbContext _jokesDbContext; // instance třídy definující databázi - umožňuje přístup k databázi
        public JokesService(JokesDbContext jokesDbContext) { // konstruktor pomocí dependenci injection vloží jako parametr objekt umoňující práci s databází
            _jokesDbContext = jokesDbContext;
        }

        public List<Joke> GetAll() { // výpis všech vtipů
            return _jokesDbContext.jokes.ToList();
        }
        public IActionResult GetFirstJokeOfType(int type) { // první vtip s JokeTypeId == type
            var joke = _jokesDbContext.jokes.FirstOrDefault(x => x.JokeTypeId == type);
            if (joke == null) {
                return NotFound();
            } else {
                return Ok(joke);
            }
        }
        public IActionResult GetNextJokeOfType(int id, int type) { // vrátí následující vtip daného typu
            var joke = _jokesDbContext.jokes.Where(x => x.JokeTypeId == type).FirstOrDefault(x => x.Id == id);
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
            var joke = _jokesDbContext.jokes.Where(x => x.JokeTypeId == type).FirstOrDefault(x => x.Id == id);
            if (joke == null) { // kontrola existence vtipu s daným id a typem
                return GetFirstJokeOfType(type); // první vtip s JokeTypeId == type
            } else {
                if (_jokesDbContext.jokes.Where(x => x.JokeTypeId == type).First() != joke) { // kontrola že vtip není první daného typu
                    var prevJoke = _jokesDbContext.jokes.Where(x => x.JokeTypeId == type).OrderBy(x => x.Id).Where(x => x.Id < id).Last(); // vyhledání předchozího vtipu
                    return Ok(prevJoke);
                } else {
                    var prevJoke = _jokesDbContext.jokes.Where(x => x.JokeTypeId == type).OrderBy(x=>x.Id).Last();// poslední vtip s JokeTypeId == type
                    return Ok(prevJoke);
                }
            }
        }

        public IActionResult PostNewJoke(Joke joke) { // vložení nového vtipu
            _jokesDbContext.jokes.Add(joke);
            _jokesDbContext.SaveChanges();
            if (joke == null) {
                return NotFound();
            } else {
                return Ok(joke);
            }
        }

        public IActionResult DeleteJoke(int id) { // vymazání vtipu
            var joke = _jokesDbContext.jokes.FirstOrDefault(x => x.Id == id);
            if (joke == null) { // kontrola existence vtipu s daným id a typem
                return NotFound();
            } else {
                _jokesDbContext.jokes.Remove(joke);
                _jokesDbContext.SaveChanges();
                return Ok(joke);
            }
        }

        public IActionResult PutJoke(int id, Joke updatedJoke) { // oprava vtipu
            var joke = _jokesDbContext.jokes.FirstOrDefault(x => x.Id == id);
            if (joke == null) { // kontrola existence vtipu s daným id a typem
                return NotFound();
            } else {
                joke.Evaluation = updatedJoke.Evaluation;
                joke.EvaluationCount = updatedJoke.EvaluationCount;
                joke.Content = updatedJoke.Content;
                _jokesDbContext.SaveChanges();
                return Ok(joke);
            }
        }
    }
}
