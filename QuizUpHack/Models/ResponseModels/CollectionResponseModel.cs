﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuizUpHack;
//
//    var collectionResponseModel = CollectionResponseModel.FromJson(jsonString);

namespace QuizUpHack
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CollectionResponseModel
    {
        [JsonProperty("collection")]
        public Collection Collection { get; set; }

        [JsonProperty("topics")]
        public List<CollectionResponseModelTopic> Topics { get; set; }
    }

    public partial class Collection
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("widgets")]
        public List<Widget> Widgets { get; set; }
    }

    public partial class Widget
    {
        [JsonProperty("topics", NullValueHandling = NullValueHandling.Ignore)]
        public List<WidgetTopic> Topics { get; set; }

        [JsonProperty("widget_id")]
        public string WidgetId { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Image Image { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class Link
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class WidgetTopic
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public partial class CollectionResponseModelTopic
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("creator", NullValueHandling = NullValueHandling.Ignore)]
        public Creator Creator { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("banner_name")]
        public string BannerName { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("rank_titles")]
        public RankTitles RankTitles { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("published_languages")]
        public List<string> PublishedLanguages { get; set; }

        [JsonProperty("update_mark")]
        public DateTimeOffset? UpdateMark { get; set; }

        [JsonProperty("new_mark")]
        public DateTimeOffset? NewMark { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("icon_asset")]
        public object IconAsset { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("play_count")]
        public long PlayCount { get; set; }

        [JsonProperty("seeking_contributions")]
        public bool SeekingContributions { get; set; }

        [JsonProperty("facebook_like_ids")]
        public List<string> FacebookLikeIds { get; set; }

        [JsonProperty("sponsorship")]
        public object Sponsorship { get; set; }

        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        [JsonProperty("network")]
        public object Network { get; set; }

        [JsonProperty("country")]
        public object Country { get; set; }

        [JsonProperty("primary_collection")]
        public PrimaryCollection PrimaryCollection { get; set; }
    }

    public partial class Creator
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Icon
    {
        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        [JsonProperty("color")]
        public Color Color { get; set; }

        [JsonProperty("shape", NullValueHandling = NullValueHandling.Ignore)]
        public string Shape { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Color
    {
        [JsonProperty("red")]
        public long Red { get; set; }

        [JsonProperty("green")]
        public long Green { get; set; }

        [JsonProperty("blue")]
        public long Blue { get; set; }
    }

    public partial class PrimaryCollection
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class RankTitles
    {
        [JsonProperty("level_60", NullValueHandling = NullValueHandling.Ignore)]
        public string Level60 { get; set; }

        [JsonProperty("level_20", NullValueHandling = NullValueHandling.Ignore)]
        public string Level20 { get; set; }

        [JsonProperty("level_70", NullValueHandling = NullValueHandling.Ignore)]
        public string Level70 { get; set; }

        [JsonProperty("level_100", NullValueHandling = NullValueHandling.Ignore)]
        public string Level100 { get; set; }

        [JsonProperty("level_5", NullValueHandling = NullValueHandling.Ignore)]
        public string Level5 { get; set; }

        [JsonProperty("level_15", NullValueHandling = NullValueHandling.Ignore)]
        public string Level15 { get; set; }

        [JsonProperty("level_40", NullValueHandling = NullValueHandling.Ignore)]
        public string Level40 { get; set; }

        [JsonProperty("level_80", NullValueHandling = NullValueHandling.Ignore)]
        public string Level80 { get; set; }

        [JsonProperty("level_30", NullValueHandling = NullValueHandling.Ignore)]
        public string Level30 { get; set; }

        [JsonProperty("level_50", NullValueHandling = NullValueHandling.Ignore)]
        public string Level50 { get; set; }

        [JsonProperty("level_10", NullValueHandling = NullValueHandling.Ignore)]
        public string Level10 { get; set; }

        [JsonProperty("level_90", NullValueHandling = NullValueHandling.Ignore)]
        public string Level90 { get; set; }

        [JsonProperty("level_25", NullValueHandling = NullValueHandling.Ignore)]
        public string Level25 { get; set; }
    }

   
   
    public partial class CollectionResponseModel
    {
        public static CollectionResponseModel FromJson(string json) => JsonConvert.DeserializeObject<CollectionResponseModel>(json, QuizUpHack.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CollectionResponseModel self) => JsonConvert.SerializeObject(self, QuizUpHack.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
   
}
