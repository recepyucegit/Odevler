namespace Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
