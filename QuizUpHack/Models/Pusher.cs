using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Pusher
    {
        [JsonProperty("auth")]
        public string Auth { get; set; }

        [JsonProperty("channel_data")]
        public string ChannelData { get; set; }
    }
}