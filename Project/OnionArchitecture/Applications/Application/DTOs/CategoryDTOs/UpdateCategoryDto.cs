using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.CategoryDTOs
{
    public class UpdateCategoryDto
    {

        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public string? Description { get; set; }
    }
}
