using System;
using Mesi.Io.Api.Clipboard.Data;
using Mesi.Io.Api.Clipboard.Models;

namespace Mesi.Io.Api.Clipboard
{
    internal static class Mapping
    {
        public static MongoClipboardEntry ToMongo(this ClipboardEntry entry) => new MongoClipboardEntry(){Content = entry.Content, UserId = entry.UserId.ToString(), CreatedAt = entry.CreatedAt};
        public static ClipboardEntry ToDomain(this MongoClipboardEntry entry) => new ClipboardEntry(Guid.Parse(entry.UserId), entry.Content, entry.CreatedAt);
    }
}