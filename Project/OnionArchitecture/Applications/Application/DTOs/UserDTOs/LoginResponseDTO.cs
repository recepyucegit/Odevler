namespace Application.DTOs.UserDTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
