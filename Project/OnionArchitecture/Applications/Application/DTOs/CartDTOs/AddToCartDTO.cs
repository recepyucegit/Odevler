using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.CartDTOs
{
    public class AddToCartDTO
    {
        //Sepete ürün eklemek için kullanılır
        
            [Required(ErrorMessage = "Ürün ID gereklidir")]
            public int ProductId { get; set; }


        [Required(ErrorMessage = "Miktar gereklidir")]
        [Range(1, 1000, ErrorMessage = "Miktar 1 ile 1000 arasında olmalıdır")]
        public int Quantity { get; set; } = 1;
             
        
    }
}
