using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Picture
    {
        [JsonProperty("formats")]
        public Formats Formats { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }
}