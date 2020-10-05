namespace SchoolDBAPI.Library.Models
{
    public class Address : IContact
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string StreetNum { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        // prop for full address format
        public string FullAddress {
            get 
            {
                return $"{StreetNum} {Street}, {Suburb}, {State} {Postcode}";
            }
        }
    }
}