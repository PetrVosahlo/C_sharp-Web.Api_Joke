using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Web.Api_Joke {
    public class Joke_Weather {
        public int Id { get; set; }
        public double Evaluation { get; set; }
        public int EvaluationCount { get; set; }
        public string Content { get; set; }
        [StringLength(60)]
        public string WeatherType { get; set; }
        [StringLength(15)]
        public string Temperature { get; set; }
        [StringLength(15)]
        public string WindSpeed { get; set; }
        [StringLength(15)]
        public string Season { get; set; }
    }
}
