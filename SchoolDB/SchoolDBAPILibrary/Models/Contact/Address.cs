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
        // prop for full address format
        public string FullAddress {
            get 
            {
                return $"{StreetAddress}, {Suburb}, {City}, {State} {Postcode}";
            }
        }
    }
}