namespace SchoolDBAPI.Library.Models
{
    public class Address : IContact
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public bool IsPrimary { get; set; }
        

    }
}