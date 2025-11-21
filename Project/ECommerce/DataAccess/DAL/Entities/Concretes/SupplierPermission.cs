using DAL.Entities.Abstracts;

namespace DAL.Entities.Concretes
{
    public class SupplierPermission : BaseClass
    {
        public int SupplierId { get; set; }
        public string Permission { get; set; }  // "ReadProduct", "AddProduct", vb.

        // Navigation property
        public Supplier Supplier { get; set; }
    }
}