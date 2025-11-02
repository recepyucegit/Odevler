using System.Security.Cryptography.X509Certificates;

namespace Application.DTOs.CartDTOs
{
    public class CartDTO
    {
        // Kullanıcının sepet bilgilerini temsil eder
        public CartDTO()
        {
            Items = new List<CartItemDTO>();
        }
        public List<CartItemDTO> Items { get; set; }

        //Spetteki toplam ürün sayısı

        public int TotalItemCount => Items.Sum(x => x.Quantity);

        //Sepetteki toplam tutar
        public decimal TotalAmount => Items.Sum(x => x.TotalPrice);

        //Sepete ürün ekle veya miktarını artır





    }

    
}
