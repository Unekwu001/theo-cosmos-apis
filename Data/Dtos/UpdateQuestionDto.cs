
using Data.Enums;
using Newtonsoft.Json;

namespace Data.Dtos
{
    public class UpdateQuestionDto
    {
        public string TheQuestion { get; set; }

        public QuestionTypeEnum QuestionType { get; set; }

        public Guid ProgramId { get; set; }
    }
}
