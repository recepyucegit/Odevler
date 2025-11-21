using DAL.Entities.Abstracts;
using System.Collections.Generic;

namespace DAL.Entities.Concretes
{
    public class Supplier : BaseClass
    {
        public string CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Email { get; set; }
        public string? Username { get; set; }  
        public string? PasswordHash { get; set; }

        // Navigation property (örnek: Supplier -> Products ilişkisi olabilir)
        public List<Product> Products { get; set; } = new List<Product>();
        public List<SupplierPermission> Permissions { get; set; } = new List<SupplierPermission>();
    }
}
