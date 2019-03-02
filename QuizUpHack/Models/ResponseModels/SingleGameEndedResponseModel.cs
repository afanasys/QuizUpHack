
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuizUpHack.Models.ResponseModels
{
    public partial class SingleGameEndedResponseModel
    {
        [JsonProperty("game_ended_status")]
        public GameEndedStatus GameEndedStatus { get; set; }
    }

    public partial class GameEndedStatus
    {
        [JsonProperty("game")]
        public Game Game { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("score_history")]
        public List<object> ScoreHistory { get; set; }

        [JsonProperty("previous_high_score")]
        public long PreviousHighScore { get; set; }

        [JsonProperty("games_played")]
        public long GamesPlayed { get; set; }

        [JsonProperty("gems_spent")]
        public GemsSpent GemsSpent { get; set; }
    }
    

    public partial class GemsSpent
    {
        [JsonProperty("continue")]
        public long Continue { get; set; }

        [JsonProperty("shuffle")]
        public long Shuffle { get; set; }
    }

    public partial class SingleGameEndedResponseModel
    {
        public static SingleGameEndedResponseModel FromJson(string json) => JsonConvert.DeserializeObject<SingleGameEndedResponseModel>(json, QuizUpHack.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SingleGameEndedResponseModel self) => JsonConvert.SerializeObject(self, QuizUpHack.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
