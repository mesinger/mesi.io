using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mesi.Io.Api.Clipboard.Data
{
    public class MongoClipboardEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        [BsonElement("id")] public string UserId { get; set; } = null!;
        [BsonElement("content")] public string Content { get; set; } = null!;
        [BsonElement("created_at")] public DateTime CreatedAt { get; set; }
    }
}