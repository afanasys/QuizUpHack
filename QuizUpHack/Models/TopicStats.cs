using System;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class TopicStats
    {
        [JsonProperty("average_response_time")]
        public double AverageResponseTime { get; set; }

        [JsonProperty("average_xp")]
        public long AverageXp { get; set; }

        [JsonProperty("games_played")]
        public long GamesPlayed { get; set; }

        [JsonProperty("last_played")]
        public string LastPlayed { get; set; }

        [JsonProperty("survival_game_count")]
        public long SurvivalGameCount { get; set; }

        [JsonProperty("survival_high_score")]
        public long SurvivalHighScore { get; set; }

        [JsonProperty("survival_total_xp")]
        public long SurvivalTotalXp { get; set; }

        [JsonProperty("topic")]
        public Topic Topic { get; set; }

        [JsonProperty("topic_slug")]
        public string TopicSlug { get; set; }

        [JsonProperty("total_draws")]
        public long TotalDraws { get; set; }

        [JsonProperty("total_losses")]
        public long TotalLosses { get; set; }

        [JsonProperty("total_network_errors")]
        public long TotalNetworkErrors { get; set; }

        [JsonProperty("total_surrenders")]
        public long TotalSurrenders { get; set; }

        [JsonProperty("total_wins")]
        public long TotalWins { get; set; }

        [JsonProperty("total_xp")]
        public long TotalXp { get; set; }

        [JsonProperty("xp_level")]
        public XpLevel XpLevel { get; set; }
    }
}