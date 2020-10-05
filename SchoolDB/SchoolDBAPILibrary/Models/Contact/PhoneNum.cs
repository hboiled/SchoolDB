namespace SchoolDBAPI.Library.Models
{
    public class PhoneNum : IContact
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Number { get; set; }
    }
}