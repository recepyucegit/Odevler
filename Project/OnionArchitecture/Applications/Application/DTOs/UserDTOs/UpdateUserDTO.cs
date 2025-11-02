using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }

    }
}
