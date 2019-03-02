using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Xp
    {
        [JsonProperty("finish_xp")]
        public long FinishXp { get; set; }

        [JsonProperty("match_xp")]
        public long MatchXp { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("win_xp")]
        public long WinXp { get; set; }

        [JsonProperty("xp_multiplier")]
        public double XpMultiplier { get; set; }
    }
}