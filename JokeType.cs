using System.ComponentModel.DataAnnotations;

namespace Web.Api_Joke {
    public class JokeType { // definice tabulky JokeType
        public int Id { get; set; }
        [StringLength(25)]  // maximální velikost Name je 25 znaků
        public string Type { get; set; }
        public ICollection<Joke_General>? TypeJokes { get; set; }
    }
}
