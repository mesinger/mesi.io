using System;

namespace Mesi.Io.Api.Clipboard.Models
{
    public class ClipboardEntry
    {
        public ClipboardEntry(Guid userId, string content, DateTime createdAt)
        {
            UserId = userId;
            Content = content;
            CreatedAt = createdAt;
        }

        public Guid UserId { get; }
        public string Content { get; }
        public DateTime CreatedAt { get; }
    }
}