using Newtonsoft.Json;

namespace QuizUpHack.Models.ResponseModels
{
    public partial class GameResponseModel
    {
        [JsonProperty("game")]
        public Models.Game Game { get; set; }

        [JsonProperty("pusher")]
        public Pusher Pusher { get; set; }

        [JsonProperty("topic")]
        public Topic Topic { get; set; }
    }

    public partial class GameResponseModel
    {
        public static GameResponseModel FromJson(string json) => JsonConvert.DeserializeObject<GameResponseModel>(json, Converter.Settings);
    }
}
