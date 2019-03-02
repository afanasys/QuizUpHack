using Newtonsoft.Json;

namespace QuizUpHack.Models.RequestModels
{
    public partial class GameRequestModel
    {
        [JsonProperty("notify")]
        public bool Notify { get; set; }

        [JsonProperty("rematch")]
        public bool Rematch { get; set; }

        [JsonProperty("socket_id")]
        public string SocketId { get; set; }

        [JsonProperty("topic_slug")]
        public string TopicSlug { get; set; }

        [JsonProperty("tournamentId")]
        public string TournamentId { get; set; }
        public static GameRequestModel FromJson(string json) => JsonConvert.DeserializeObject<GameRequestModel>(json, Converter.Settings);
    }

   
}
