namespace CleanArchitecture.Application.Models
{
    public class EmailSettings
    {
        public string? ApiKey { get; set; }
        public string? Password { get; set; }
        public string? FromAdress { get; set; }
        public string? FromName { get; set; }
    }
}
