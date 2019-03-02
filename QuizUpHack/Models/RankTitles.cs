using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class RankTitles
    {
        [JsonProperty("level_10")]
        public string Level10 { get; set; }

        [JsonProperty("level_100")]
        public string Level100 { get; set; }

        [JsonProperty("level_15")]
        public string Level15 { get; set; }

        [JsonProperty("level_20")]
        public string Level20 { get; set; }

        [JsonProperty("level_25")]
        public string Level25 { get; set; }

        [JsonProperty("level_30")]
        public string Level30 { get; set; }

        [JsonProperty("level_40")]
        public string Level40 { get; set; }

        [JsonProperty("level_5")]
        public string Level5 { get; set; }

        [JsonProperty("level_50")]
        public string Level50 { get; set; }

        [JsonProperty("level_60")]
        public string Level60 { get; set; }

        [JsonProperty("level_70")]
        public string Level70 { get; set; }

        [JsonProperty("level_80")]
        public string Level80 { get; set; }

        [JsonProperty("level_90")]
        public string Level90 { get; set; }
    }
}