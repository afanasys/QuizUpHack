using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Formats
    {
        [JsonProperty("jpg")]
        public Jpg Jpg { get; set; }
    }
}