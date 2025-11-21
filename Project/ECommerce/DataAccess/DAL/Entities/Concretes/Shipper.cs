using DAL.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Concretes
{
    public class Shipper : BaseClass
    {
        public string ShipperName { get; set; }
        public string? ContactInfo { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation property
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
