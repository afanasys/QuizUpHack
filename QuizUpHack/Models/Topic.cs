using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizUpHack.Models
{
    public partial class Topic
    {
        [JsonProperty("banner_name")]
        public string BannerName { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("new_mark")]
        public object NewMark { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("primary_collection")]
        public PrimaryCollection PrimaryCollection { get; set; }

        [JsonProperty("published_languages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> PublishedLanguages { get; set; }

        [JsonProperty("rank_titles", NullValueHandling = NullValueHandling.Ignore)]
        public RankTitles RankTitles { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("update_mark")]
        public object UpdateMark { get; set; }
    }
}