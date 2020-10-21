namespace SchoolDBAPI.Library.Models
{
    public enum EmailOwner
    {
        Personal,
        Guardian,
        School
    }
    public class Email
    {
        public int Id { get; set; }        
        public int StudentId { get; set; }
        public string EmailAddress { get; set; }
        public bool IsSchoolEmail { get; set; }
        public EmailOwner Owner { get; set; }
    }
}