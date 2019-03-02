using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class FiftyFifty
    {
        [JsonProperty("increment_value")]
        public long IncrementValue { get; set; }

        [JsonProperty("limit_per_game")]
        public long LimitPerGame { get; set; }

        [JsonProperty("only_for_wildcard")]
        public bool OnlyForWildcard { get; set; }

        [JsonProperty("start_price_point")]
        public long StartPricePoint { get; set; }
    }
}