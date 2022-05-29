using System.ComponentModel.DataAnnotations;

namespace Web.Api_Joke { // definice tabulky User
    public class User {
        public int id { get; set; }
        [StringLength(30)] // maximální velikost Name je 30 znaků
        public string Name { get; set; } = String.Empty;
        [StringLength(30)] // maximální velikost Name je 30 znaků
        private string Password { get; set; } = String.Empty;
    }
}
