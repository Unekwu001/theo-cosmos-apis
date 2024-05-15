using Data.Enums;
using Newtonsoft.Json;
namespace Data.Models
{
    public class QuestionType
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public QuestionTypeEnum Type { get; set; }  
    }
}
