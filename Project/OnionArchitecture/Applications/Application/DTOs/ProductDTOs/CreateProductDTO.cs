using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public short UnitsInStock { get; set; }

        public string? Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SupplierId { get; set; }
    }
}
