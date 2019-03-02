using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class ConsumableConfigurations
    {
        [JsonProperty("fifty_fifty")]
        public FiftyFifty FiftyFifty { get; set; }


        [JsonProperty("refresh")]
        public FiftyFifty Refresh { get; set; }

        [JsonProperty("two_picks")]
        public FiftyFifty TwoPicks { get; set; }
      
        [JsonProperty("skip_question")]
        public FiftyFifty SkipQuestion { get; set; }
    }
}