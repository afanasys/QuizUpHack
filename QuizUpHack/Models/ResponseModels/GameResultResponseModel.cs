using Newtonsoft.Json;

namespace QuizUpHack.Models.ResponseModels
{
    public partial class GameResultResponseModel
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
        public static GameResultResponseModel FromJson(string json) => JsonConvert.DeserializeObject<GameResultResponseModel>(json, Converter.Settings);
    }

    public partial class TopicStats
    {

        [JsonProperty("total_match_xp")]
        public long TotalMatchXp { get; set; }
    }

   
}
