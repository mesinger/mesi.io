namespace Mesi.Io.Api.User.DTO
{
    public class RegistrationRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}