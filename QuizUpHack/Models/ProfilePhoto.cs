using System;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class ProfilePhoto
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}