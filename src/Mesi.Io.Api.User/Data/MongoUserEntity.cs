using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mesi.Io.Api.User.Data
{
    public class MongoUserEntity
    {
        [BsonId] [BsonRepresentation(BsonType.ObjectId)] public string Id { get; set; } = null!;
        [BsonElement("user_id")] public string UserId { get; set; } = null!;
        [BsonElement("username")] public string UserName { get; set; } = null!;
        [BsonElement("email")] public string Email { get; set; } = null!;
        [BsonElement("password")] public string Password { get; set; } = null!;
        [BsonElement("registered_at")] public DateTime RegisteredAt { get; set; }
        [BsonElement("roles")] public IEnumerable<string> Roles { get; set; } = null!;
    }
}