using Microsoft.EntityFrameworkCore;

namespace Web.Api_Joke {
    public class JokesDbContext:DbContext { // třída definující databázi JokesDbContext
        public JokesDbContext(DbContextOptions<JokesDbContext> options):base(options) {
        }
        public DbSet<Joke> jokes { get; set; } // definice tabulky jokes
        public DbSet<User> users { get; set; } // definice tabulky users
        public DbSet<JokeType> jokeTypes { get; set; } // definice tabulky jokeTypes
    }
}
