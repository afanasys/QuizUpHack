using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class XpLevel
    {
        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("xp_end")]
        public long XpEnd { get; set; }

        [JsonProperty("xp_start")]
        public long XpStart { get; set; }
    }
}