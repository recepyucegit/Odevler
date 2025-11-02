using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.SupplierDTOs
{
    public class UpdateSupplierDTO
    {
        public int Id { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string? Address { get; set; }
    }
}