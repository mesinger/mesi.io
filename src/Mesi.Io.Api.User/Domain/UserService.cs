using System;
using System.Threading.Tasks;
using JWT.Algorithms;
using JWT.Builder;
using Mesi.Io.Api.User.Data;
using Mesi.Io.Api.User.Except;
using Mesi.Io.Api.User.Models;
using Microsoft.Extensions.Logging;

namespace Mesi.Io.Api.User.Domain
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task<Models.User> Register(string email, string password, string username)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(username)) throw new InvalidInputException();
            
            var existingUser = await _userRepository.GetByEmail(email);
            if(existingUser != null) throw new EmailAlreadyRegisteredException();

            existingUser = await _userRepository.GetByName(username);
            if(existingUser != null) throw new UserNameAlreadyRegisteredException();

            var userId = Guid.NewGuid();
            var hashedPassword = _passwordHasher.hash(password);
            var registered = DateTime.UtcNow;
            var roles = new[] { Roles.Default };

            var user = new Models.User(userId, username, email, hashedPassword, registered, roles);
            _userRepository.Save(user);
            
            _logger.LogInformation("Registerd new user: {}, {}", user.UserName, user.Email);

            return user;
        }

        public async Task<Models.User?> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null) return null;

            var hashedPassword = _passwordHasher.hash(password);
            
            return hashedPassword != user.Password ? null : user;
        }

        public string GenerateJWT(Models.User user)
        {
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1")
                .AddClaim("iss", "mesi.io")
                .AddClaim("sub", user.UserId)
                .AddClaim("aud", "default.mesi.io")
                .AddClaim("exp", DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeMilliseconds())
                .AddClaim("name", user.UserName)
                .AddClaim("email", user.Email)
                .Encode();
        }

        public Task<Models.User?> GetByName(string username)
        {
            return _userRepository.GetByName(username);
        }

        public Task<Models.User?> GetById(Guid userId)
        {
            return _userRepository.GetById(userId.ToString());
        }
    }
}