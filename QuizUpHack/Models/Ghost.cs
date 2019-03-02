using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Ghost
    {
        [JsonProperty("answers")]
        public Dictionary<string, Answer> Answers { get; set; }

        [JsonProperty("is_explicit")]
        public bool IsExplicit { get; set; }

        [JsonProperty("player")]
        public GhostPlayer Player { get; set; }

        [JsonProperty("topic_stats")]
        public TopicStats TopicStats { get; set; }

        [JsonProperty("xp_multiplier")]
        public long XpMultiplier { get; set; }
    }
}