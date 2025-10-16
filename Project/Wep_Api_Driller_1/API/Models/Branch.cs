namespace WebApiCRUd.Models
{
    public class Branch
    {
        // Primary Key - Her şubenin benzersiz kimliği
        public int BranchId { get; set; }
        // Şube adı - NOT null olmalı
        public string BranchName { get; set; }=string.Empty;
        // Şehir bilgisi - NOT null olmalı
        public string City { get; set; }=string.Empty;
        // Telefon numarası - null olabilir
        public string? Phone { get; set; }
        // Şubenin aktif olup olmadığını gösterir
        public bool IsActive { get; set; }
        // Açılış Tarihi
        public DateTime OpeningDate { get; set; }
        // İlişkili çalışanlar - bir şubenin birden fazla çalışanı olabilir
        public ICollection<Employee>? Employees { get; set; } 
    }
}
