using System.Collections.Generic;
using Newtonsoft.Json;
using QuizUpHack.Models.ResponseModels;

namespace QuizUpHack.Models
{
    public partial class Round
    {

        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("answers")]
        public Dictionary<string, Answer> Answers { get; set; }

        [JsonProperty("question_id")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string QuestionId { get; set; }
    }
}