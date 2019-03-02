using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class AnswerElement
    {
        [JsonProperty("correct")]
        public bool Correct { get; set; }

        [JsonProperty("id")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("translations")]
        public object Translations { get; set; }
    }
}