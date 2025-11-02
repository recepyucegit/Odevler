using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CartDTOs
{
    public class CartItemDTO
    {
        //Sepetteki ürün bilgilerini temsil eder
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? Description{get; set;}

        // Tıoplam fiyat hesaplama
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
