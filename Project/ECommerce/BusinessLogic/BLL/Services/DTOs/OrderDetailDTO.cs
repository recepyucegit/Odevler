using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DTOs
{
    public class OrderDetailDTO
    {
       

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string UserId { get; set; } = "";
        public DateTime OrderDate { get; set; }

    }
}
