using Data.Enums;
using Data.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class AdditionalQuestion
    {
        public string AboutYou { get; set; }
        public DateTime YearOfGraduation { get; set; }

        [MinSelectedOptions(2)]
        public ICollection<MultipleChoiceEnum> MultipleChoice{ get; set; } 
        public bool RejectedByUkEmbassy { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime MovedToUkOn { get; set; }

    }
}
