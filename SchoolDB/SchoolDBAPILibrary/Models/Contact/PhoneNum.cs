namespace SchoolDBAPI.Library.Models
{
    public enum PhoneNumberOwner
    {
        Self,
        Guardian,
        Relative,
        Work,
        Home
    }

    public class PhoneNum : IContact
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Number { get; set; }
        public PhoneNumberOwner Owner { get; set; }
        public bool IsMobile { get; set; }
        public bool IsEmergency { get; set; }
    }
}