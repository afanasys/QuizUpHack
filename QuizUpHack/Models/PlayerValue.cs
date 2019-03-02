using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class PlayerValue
    {
        [JsonProperty("answers")]
        public Answers Answers { get; set; }

        [JsonProperty("player")]
        public PlayerPlayer Player { get; set; }

        [JsonProperty("topic_stats")]
        public TopicStats TopicStats { get; set; }

        [JsonProperty("xp_multiplier")]
        public double XpMultiplier { get; set; }
    }
}