using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Question
    {
        [JsonProperty("answers")]
        public List<AnswerElement> Answers { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("correct_answer_id")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string CorrectAnswerId { get; set; }

        [JsonProperty("id")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Id { get; set; }

        [JsonProperty("read_time")]
        public double ReadTime { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("translations")]
        public object Translations { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version_ids")]
        public Answers VersionIds { get; set; }

        [JsonProperty("resources", NullValueHandling = NullValueHandling.Ignore)]
        public Resources Resources { get; set; }
    }
}