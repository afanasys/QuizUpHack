using System;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class PurplePictureUrls
    {
        [JsonProperty("large")]
        public Uri Large { get; set; }

        [JsonProperty("mini")]
        public Uri Mini { get; set; }

        [JsonProperty("original")]
        public Uri Original { get; set; }

        [JsonProperty("square")]
        public Uri Square { get; set; }

        [JsonProperty("wallpaper/large")]
        public Uri WallpaperLarge { get; set; }

        [JsonProperty("wallpaper/original")]
        public Uri WallpaperOriginal { get; set; }
    }
}