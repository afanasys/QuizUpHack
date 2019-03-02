using System;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Jpg
    {
        [JsonProperty("md5")]
        public string Md5 { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}