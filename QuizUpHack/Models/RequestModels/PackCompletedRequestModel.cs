using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuizUpHack.Models.RequestModels
{
    public partial class PackCompletedRequestModel
    {
        [JsonProperty("question_pack")]
        public long? QuestionPack { get; set; }

        [JsonProperty("wildcard_pack")]
        public long? WildcardPack { get; set; }

        [JsonProperty("answer_id")]
        public string AnswerId { get; set; }

        [JsonProperty("failed_question_number")]
        public long FailedQuestionNumber { get; set; }

        [JsonProperty("time_in_millis")]
        public long TimeInMillis { get; set; }
    }

    public partial class PackCompletedModel
    {
        public static PackCompletedModel FromJson(string json) => JsonConvert.DeserializeObject<PackCompletedModel>(json, QuizUpHack.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PackCompletedModel self) => JsonConvert.SerializeObject(self, QuizUpHack.Converter.Settings);
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
