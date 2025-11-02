using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        [Required]
        public string CategoryName { get; set; }

        public string? Description { get; set; }

    }
}
