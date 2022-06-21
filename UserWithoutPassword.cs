using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Api_Joke { // definice tabulky User
    public class UserWithoutPassword {
        [Key]
        //[StringLength(30)] // maximální velikost Name je 30 znaků
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }
        [StringLength(30)] // maximální velikost password je 30 znaků
        public ICollection<Joke_General>? UserJokes { get; set; }
    }
}
