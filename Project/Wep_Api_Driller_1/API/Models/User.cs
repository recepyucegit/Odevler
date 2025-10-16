using System.ComponentModel.DataAnnotations;

namespace WebApiCRUD.Models
{
    public class User
    {
        public  int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

    }
}
