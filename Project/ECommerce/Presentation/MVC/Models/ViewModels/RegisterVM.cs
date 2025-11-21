using System.ComponentModel.DataAnnotations; //bu kütüphane property'lere attribute'ler ekleyebilmemizi sağlar. bu attribute'ler validasyon için kullanılır.

namespace MVC.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Kullanıcı boş geçilemez!")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Email boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre (Tekrar) boş geçilemez!")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

    }
}
