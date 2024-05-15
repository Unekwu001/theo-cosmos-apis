namespace Data.Models
{
    public class Programme
    {
        public Guid Id { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; } 
        public virtual ICollection<PersonalInformation> PersonalInformations { get; set; }
        public virtual ICollection<Question> Questions { get; set; } 
    }
}
