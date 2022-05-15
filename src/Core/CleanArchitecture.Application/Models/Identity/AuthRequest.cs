namespace CleanArchitecture.Application.Models.Identity
{
    public class AuthRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
