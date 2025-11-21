using System.ComponentModel.DataAnnotations;

namespace MVC.Models.ViewModels
{
    public class LoginVM
    {
     


        [Required(ErrorMessage = "Email boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }

       
    }
}
