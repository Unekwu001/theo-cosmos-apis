using Data.Models;

namespace Data.Dtos
{
    public class ApplicationDto
    {
        public PersonalInformationDto PersonalInformation { get; set; }
        public AdditionalQuestionDto AdditionalQuestion { get; set; }
    }
}
