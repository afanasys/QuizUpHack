using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Game
    {
        [JsonProperty("async")]
        public bool Async { get; set; }

        [JsonProperty("challenge")]
        public bool Challenge { get; set; }

        [JsonProperty("channel_name")]
        public string ChannelName { get; set; }

        [JsonProperty("consumable_configurations")]
        public ConsumableConfigurations ConsumableConfigurations { get; set; }

        [JsonProperty("game_type")]
        public string GameType { get; set; }

        [JsonProperty("ghost")]
        public Ghost Ghost { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("network_error")]
        public bool NetworkError { get; set; }

        [JsonProperty("players")]
        public Dictionary<string, PlayerValue> Players { get; set; }

        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }

        [JsonProperty("rejected")]
        public bool Rejected { get; set; }

        [JsonProperty("rematch")]
        public bool Rematch { get; set; }

        [JsonProperty("result_player_ids")]
        public List<object> ResultPlayerIds { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("surrendered_id")]
        public object SurrenderedId { get; set; }

        [JsonProperty("topic_slug")]
        public string TopicSlug { get; set; }
    }
}