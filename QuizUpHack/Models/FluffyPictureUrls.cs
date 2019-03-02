using System;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class FluffyPictureUrls
    {
        [JsonProperty("large")]
        public Uri Large { get; set; }

        [JsonProperty("mini")]
        public Uri Mini { get; set; }

        [JsonProperty("original")]
        public Uri Original { get; set; }

        [JsonProperty("square")]
        public Uri Square { get; set; }
    }
}