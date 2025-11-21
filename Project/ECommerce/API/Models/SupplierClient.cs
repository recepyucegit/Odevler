namespace API.Models
{
    public class SupplierClient
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public List<string> Permissions { get; set; } = new List<string>();
    }

    public static class SupplierPermissions
    {
        public const string ReadProduct = "ReadProduct";
        public const string AddProduct = "AddProduct";
        public const string EditProduct = "EditProduct";
        public const string DeleteProduct = "DeleteProduct";
    }
}