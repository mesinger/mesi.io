using System;
using Mesi.Io.Api.User.Data;

namespace Mesi.Io.Api.User
{
    internal static class Mapping
    {
        public static Models.User ToDomain(this MongoUserEntity user) =>
            new Models.User(Guid.Parse(user.UserId), user.UserName, user.Email, user.Password, user.RegisteredAt, user.Roles);
        
        public static MongoUserEntity ToMongo(this Models.User user) => new MongoUserEntity()
        {
            UserId = user.UserId.ToString(),
            Email = user.Email, Password = user.Password, UserName = user.UserName, RegisteredAt = user.RegisteredAt,
            Roles = user.Roles
        };
    }
}