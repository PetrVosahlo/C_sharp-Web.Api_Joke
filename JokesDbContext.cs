using Microsoft.EntityFrameworkCore;

namespace Web.Api_Joke {
    public class JokesDbContext:DbContext { // třída definující databázi JokesDbContext
        public JokesDbContext(DbContextOptions<JokesDbContext> options):base(options) {
        }
        public DbSet<Joke_General> jokes_General { get; set; } // definice tabulky jokes - vtipy s výjimkou vtipů o počasí
        public DbSet<Joke_Weather> jokes_Weather { get; set; } // definice tabulky jokes - vtipy o počasí
        public DbSet<User> users { get; set; } // definice tabulky users
        public DbSet<JokeType> jokeTypes { get; set; } // definice tabulky jokeTypes
    }
}
