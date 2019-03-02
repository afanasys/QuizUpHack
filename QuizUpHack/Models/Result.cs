using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Result
    {
        [JsonProperty("banner_slugs")]
        public BannerSlugs BannerSlugs { get; set; }

        [JsonProperty("banners")]
        public BannerSlugs Banners { get; set; }

        [JsonProperty("first_view")]
        public bool FirstView { get; set; }

        [JsonProperty("game")]
        public Game Game { get; set; }

        [JsonProperty("game_ended_timestamp")]
        public DateTimeOffset GameEndedTimestamp { get; set; }

        [JsonProperty("game_started_timestamp")]
        public DateTimeOffset GameStartedTimestamp { get; set; }

        [JsonProperty("ghost_match")]
        public bool GhostMatch { get; set; }

        [JsonProperty("loser_id")]
        public string LoserId { get; set; }

        [JsonProperty("network_error")]
        public bool NetworkError { get; set; }

        [JsonProperty("new_questions")]
        public NewQuestions NewQuestions { get; set; }

        [JsonProperty("rewards")]
        public BannerSlugs Rewards { get; set; }

        [JsonProperty("rounds")]
        public List<Round> Rounds { get; set; }

        [JsonProperty("surrendered_id")]
        public object SurrenderedId { get; set; }

        [JsonProperty("topic_slug")]
        public string TopicSlug { get; set; }

        [JsonProperty("was_tie")]
        public bool WasTie { get; set; }

        [JsonProperty("winner_id")]
        public string WinnerId { get; set; }

        [JsonProperty("xps")]
        public Dictionary<string, Xp> Xps { get; set; }
    }
}