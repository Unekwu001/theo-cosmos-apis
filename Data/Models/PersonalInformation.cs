using Data.Enums;
using System.Text.Json.Serialization;
namespace Data.Models
{
    public class PersonalInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }    
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public Guid ProgramId { get; set; }

        [JsonIgnore]
        public virtual Programme Programme { get; set; }
    }
}
