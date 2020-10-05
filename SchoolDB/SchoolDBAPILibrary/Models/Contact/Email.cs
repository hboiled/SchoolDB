namespace SchoolDBAPI.Library.Models
{
    public class Email : IContact
    {
        public int Id { get; set; }        
        public int PersonId { get; set; }
        public string EmailAddress { get; set; }
    }
}