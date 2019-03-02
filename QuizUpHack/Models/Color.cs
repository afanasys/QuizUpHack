using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Color
    {
        [JsonProperty("blue")]
        public long Blue { get; set; }

        [JsonProperty("green")]
        public long Green { get; set; }

        [JsonProperty("red")]
        public long Red { get; set; }
    }
}