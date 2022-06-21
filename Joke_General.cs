using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Web.Api_Joke {
    public class Joke_General { // definice tabulky Joke
        public int Id { get; set; }
        [StringLength(15)]
        public string? ChangePassword { get; set; }
        public double Evaluation { get; set; }
        public int EvaluationCount { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        [JsonIgnore] // nutné - jinak json vytvoří pro UserId přez vazební vlastnost (User? User) v Userovy zápis ICollection<Joke>
                     // s hodnotou UserId přes vazební vlastnost (User? User) v Userovy zápis ICollection<Joke> s hodnotou UserId
                     // a stále dokola
        public User? User { get; set; }
        public int JokeTypeId { get; set; }
        [ForeignKey("JokeTypeId")]
        [JsonIgnore]// nutné - jinak json vytvoří pro JokeTypeId přez vazební vlastnost (JokeType? JokeType) v JokeType zápis ICollection<Joke>
                    // s hodnotou JokeTypeId přes vazební vlastnost (JokeType? JokeType) v JokeType zápis ICollection<Joke> s hodnotou JokeTypeId
                    // a stále dokola
        public JokeType? JokeType { get; set; }
    }
}
