using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.UserDTOs
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Kullanıcı adı veya email gereklidir")]
        public string UserNameOrEmail { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
