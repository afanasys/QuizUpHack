using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizUpHack.Models.RequestModels
{
    public partial class GameResultRequestModel
    {
        [JsonProperty("async")]
        public bool Async { get; set; }

        [JsonProperty("client_clock")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long ClientClock { get; set; }

        [JsonProperty("network_error")]
        public bool NetworkError { get; set; }

        [JsonProperty("participants")]
        public List<string> Participants { get; set; }

        [JsonProperty("rounds")]
        public List<Round> Rounds { get; set; }
    }

    public partial class GameResultRequestModel
    {
        public static GameResultRequestModel FromJson(string json) => JsonConvert.DeserializeObject<GameResultRequestModel>(json, Converter.Settings);
    }
}
