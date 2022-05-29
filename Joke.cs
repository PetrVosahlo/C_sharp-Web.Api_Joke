namespace Web.Api_Joke {
    public class Joke { // definice tabulky Joke
        public int Id { get; set; }
        public double Evaluation { get; set; }
        public int EvaluationCount { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int JokeTypeId { get; set; }
        public JokeType? JokeType { get; set; }
        public double Temperature { get; set; }
        public bool SunRain { get; set; }
        public double Wind { get; set; }
        public bool Snow { get; set; }
        public byte Season { get; set; }
    }
}
