using DAL.Entities.Abstracts;

namespace DAL.Entities.Concretes
{
    public class Category:BaseClass
    {
       
        //Sadece kategoride olması gereken özellikleri
        public string CategoryName { get; set; }
        public string? Description { get; set; } //boş geçilir.

        //ilişki kurulacak
        public List<Product> Products { get; set; }
    }
}
