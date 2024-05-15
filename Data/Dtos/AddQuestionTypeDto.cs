using Data.Enums;
using System.ComponentModel.DataAnnotations;
namespace Data.Dtos
{
    public class AddQuestionTypeDto
    {
        [EnumDataType(typeof(QuestionTypeEnum))]
        public QuestionTypeEnum Type { get; set; }
    }
}
