namespace Mesi.Io.Api.User.DTO
{
    public class AuthenticationRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}