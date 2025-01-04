namespace BlogApplication.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }=string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
