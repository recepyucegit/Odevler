using DAL.Entities.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Concretes
{
    public class Order : BaseClass
    {
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }

        // Shipper ilişkisi
        public int? ShipperId { get; set; }
        public Shipper? Shipper { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
