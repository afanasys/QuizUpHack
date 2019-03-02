using Newtonsoft.Json;
using QuizUpHack.Models.RequestModels;

namespace QuizUpHack.Models
{
    public static class Serialize
    {
        public static string ToJson(this GameRequestModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}