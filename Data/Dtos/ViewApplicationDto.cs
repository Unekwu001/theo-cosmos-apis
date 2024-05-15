using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class ViewApplicationDto
    {
        public string Id { get; set; }
        public PersonalInformationDto PersonalInformation { get; set; }
        public AdditionalQuestionDto AdditionalQuestion { get; set; }
    }
}
