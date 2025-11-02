namespace Domain.Entities
{
    public class Supplier:BaseEntity
    {
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
