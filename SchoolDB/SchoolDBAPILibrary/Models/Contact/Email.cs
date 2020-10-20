namespace SchoolDBAPI.Library.Models
{
    public enum EmailOwner
    {
        Personal,
        Guardian,
        School
    }
    public class Email : IContact
    {
        public int Id { get; set; }        
        public int PersonId { get; set; }
        public string EmailAddress { get; set; }
        public bool IsSchoolEmail { get; set; }
        public EmailOwner Owner { get; set; }
    }
}