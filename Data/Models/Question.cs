
using Data.Enums;
using Newtonsoft.Json;

namespace Data.Models
{
    public class Question
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("theQuestion")]
        public string TheQuestion { get; set; }

        [JsonProperty("questionTypeId")]
        public QuestionTypeEnum QuestionType { get; set; } 

        [JsonProperty("programId")]
        public Guid ProgramId { get; set; }

        [JsonIgnore]
        public virtual Programme Programme { get; set; }
    }
}
