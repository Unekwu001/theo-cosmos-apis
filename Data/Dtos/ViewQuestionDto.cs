using Data.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class ViewQuestionDto
    {
        public string Id { get; set; }
        public string TheQuestion { get; set; }
        public QuestionTypeEnum QuestionType { get; set; }
        public Guid ProgramId { get; set; }
    }
}
