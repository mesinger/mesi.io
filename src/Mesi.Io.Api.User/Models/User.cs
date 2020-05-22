using System;
using System.Collections.Generic;

namespace Mesi.Io.Api.User.Models
{
    public class User
    {
        public User(Guid userId, string username, string email, string password, DateTime registeredAt, IEnumerable<string> roles)
        {
            UserId = userId;
            UserName = username;
            Email = email;
            Password = password;
            RegisteredAt = registeredAt;
            Roles = roles;
        }

        public Guid UserId { get; }
        public string UserName { get; }
        public string Email { get; }
        public string Password { get; }
        public DateTime RegisteredAt { get; }
        public IEnumerable<string> Roles { get; }
    }
}