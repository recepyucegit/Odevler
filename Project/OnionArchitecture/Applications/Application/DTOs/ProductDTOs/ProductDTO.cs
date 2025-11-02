using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
