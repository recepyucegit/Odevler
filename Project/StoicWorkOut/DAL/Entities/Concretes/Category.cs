using DAL.Entities.Abstract;

namespace DAL.Entities.Concretes
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
