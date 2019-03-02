﻿namespace QuizUpHack.Models.ResponseModels
{
    // <auto-generated />
    //
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuizUpHack;
    //
    //    var tournamentGameRequestModel = TournamentGameRequestModel.FromJson(jsonString);

    namespace QuizUpHack
    {
        using System;
        using System.Collections.Generic;

        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;

        public partial class TournamentGameResponseModel
        {
            [JsonProperty("game")]
            public Game Game { get; set; }

            [JsonProperty("question_pack")]
            public QuestionPack QuestionPack { get; set; }

            [JsonProperty("highscore")]
            public long Highscore { get; set; }

            [JsonProperty("ticketsCharged")]
            public long TicketsCharged { get; set; }

            [JsonProperty("next_continue_cost")]
            public long NextContinueCost { get; set; }

            [JsonProperty("next_continue_multiplier")]
            public long NextContinueMultiplier { get; set; }

            [JsonProperty("consumable_configurations")]
            public ConsumableConfigurations ConsumableConfigurations { get; set; }
        }

        public partial class ConsumableConfigurations
        {
            [JsonProperty("fifty_fifty")]
            public FiftyFifty FiftyFifty { get; set; }

            [JsonProperty("two_picks")]
            public FiftyFifty TwoPicks { get; set; }
        }

        public partial class FiftyFifty
        {
            [JsonProperty("start_price_point")]
            public long StartPricePoint { get; set; }

            [JsonProperty("increment_value")]
            public long IncrementValue { get; set; }
        }

        public partial class Game
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("tournamentId")]
            public string TournamentId { get; set; }

            [JsonProperty("topic_slug")]
            public string TopicSlug { get; set; }

            [JsonProperty("pack")]
            public long Pack { get; set; }

            [JsonProperty("packSize")]
            public long PackSize { get; set; }

            [JsonProperty("packCount")]
            public long PackCount { get; set; }

            [JsonProperty("finished")]
            public bool Finished { get; set; }

            [JsonProperty("xp")]
            public Xp Xp { get; set; }

            [JsonProperty("pack_xp_start")]
            public long PackXpStart { get; set; }

            [JsonProperty("pack_xp_increment")]
            public long PackXpIncrement { get; set; }

            [JsonProperty("pack_xp_max")]
            public long PackXpMax { get; set; }
        }

        public partial class Xp
        {
            [JsonProperty("topic")]
            public long Topic { get; set; }

            [JsonProperty("wildcard")]
            public long Wildcard { get; set; }

            [JsonProperty("highscore")]
            public long Highscore { get; set; }

            [JsonProperty("multiplier")]
            public long Multiplier { get; set; }

            [JsonProperty("total")]
            public long Total { get; set; }

            [JsonProperty("total_topic")]
            public long TotalTopic { get; set; }
        }

        public partial class QuestionPack
        {
            [JsonProperty("pack")]
            public long Pack { get; set; }

            [JsonProperty("questions")]
            public List<Question> Questions { get; set; }
        }

        public partial class Question
        {
            [JsonProperty("id")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Id { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("answers")]
            public List<Answer> Answers { get; set; }

            [JsonProperty("correct_answer_id")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long CorrectAnswerId { get; set; }

            [JsonProperty("read_time")]
            public double ReadTime { get; set; }

            [JsonProperty("photo_url")]
            public object PhotoUrl { get; set; }
        }

        public partial class Answer
        {
            [JsonProperty("id")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Id { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }
        }

        public partial class TournamentGameResponseModel
        {
            public static TournamentGameResponseModel FromJson(string json) => JsonConvert.DeserializeObject<TournamentGameResponseModel>(json, QuizUpHack.Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this TournamentGameResponseModel self) => JsonConvert.SerializeObject(self, QuizUpHack.Converter.Settings);
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

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }
    }

}
