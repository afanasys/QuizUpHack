using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Answer
    {
        [JsonProperty("answer_id")]
        public string AnswerId { get; set; }

        [JsonProperty("answer_time")]
        public double AnswerTime { get; set; }
    }
}