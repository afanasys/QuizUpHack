using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class PlayerPlayer
    {
        [JsonProperty("banners")]
        public List<object> Banners { get; set; }

        [JsonProperty("bio")]
        public object Bio { get; set; }

        [JsonProperty("gender")]
        public object Gender { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture_urls")]
        public FluffyPictureUrls PictureUrls { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }

        [JsonProperty("profile_photo")]
        public ProfilePhoto ProfilePhoto { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("team_member")]
        public bool TeamMember { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("wallpaper")]
        public object Wallpaper { get; set; }
    }
}