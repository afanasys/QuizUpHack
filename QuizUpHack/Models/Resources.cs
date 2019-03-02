using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Resources
    {
        [JsonProperty("pictures")]
        public List<Picture> Pictures { get; set; }
    }
}