using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizUpHack.Models.ResponseModels
{
    public partial class SinglePlayerGameResponseModel
    {
        [JsonProperty("game")]
        public Game Game { get; set; }

        [JsonProperty("question_pack")]
        public QuestionPack QuestionPack { get; set; }

        [JsonProperty("wildcard_pack")]
        public WildcardPack WildcardPack { get; set; }

        [JsonProperty("highscore")]
        public long Highscore { get; set; }

        [JsonProperty("next_continue_cost")]
        public long NextContinueCost { get; set; }

        [JsonProperty("next_shuffle_cost")]
        public long NextShuffleCost { get; set; }

        [JsonProperty("consumable_configurations")]
        public ConsumableConfigurations ConsumableConfigurations { get; set; }
    }

    public partial class ConsumableConfigurations
    {
        [JsonProperty("fifty_fifty")]
        public FiftyFifty FiftyFifty { get; set; }

        [JsonProperty("two_picks")]
        public FiftyFifty TwoPicks { get; set; }

        [JsonProperty("skip_question")]
        public FiftyFifty SkipQuestion { get; set; }
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

        [JsonProperty("topic_slug")]
        public string TopicSlug { get; set; }

        [JsonProperty("pack")]
        public long Pack { get; set; }

        [JsonProperty("question_pack")]
        public long QuestionPack { get; set; }

        [JsonProperty("wildcard_pack")]
        public long WildcardPack { get; set; }

        [JsonProperty("finished")]
        public bool Finished { get; set; }

        [JsonProperty("xp")]
        public Xp Xp { get; set; }
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
        public Uri PhotoUrl { get; set; }
    }

    public partial class Answer
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class WildcardPack
    {
        [JsonProperty("pack")]
        public long Pack { get; set; }

        [JsonProperty("wildcards")]
        public List<Wildcard> Wildcards { get; set; }

        [JsonProperty("next_shuffle_cost")]
        public long NextShuffleCost { get; set; }
    }

    public partial class Wildcard
    {
        [JsonProperty("topic")]
        public Topic Topic { get; set; }

        [JsonProperty("question")]
        public Question Question { get; set; }
    }

    public partial class Topic
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        [JsonProperty("primary_collection")]
        public PrimaryCollection PrimaryCollection { get; set; }
    }

    public class Icon
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public class PrimaryCollection
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    
}
