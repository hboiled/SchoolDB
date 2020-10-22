namespace SchoolDBAPI.DTO
{
    public class AddressBasicDetailDTO
    {
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public bool IsPrimary { get; set; }
    }
}