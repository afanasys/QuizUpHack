using System;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class PrimaryCollection
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}