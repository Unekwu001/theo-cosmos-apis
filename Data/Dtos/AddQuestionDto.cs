using Data.Enums;
using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class AddQuestionDto
    {
        public string TheQuestion { get; set; }
        public QuestionTypeEnum QuestionType { get; set; }
        public Guid ProgramId { get; set; }
    }
}
