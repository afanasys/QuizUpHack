using System;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Icon
    {
        [JsonProperty("color")]
        public Color Color { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}