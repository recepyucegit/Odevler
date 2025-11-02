namespace Application.DTOs.CategoryDTOs
{
    public class CategoryDTO
    {
        //Bu DTO kategori'e bilgileri liste içerisinde ya da tekil ensne olarak bünyesine dahil eder.
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
