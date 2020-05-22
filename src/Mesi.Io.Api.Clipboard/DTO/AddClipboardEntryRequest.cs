using System;

namespace Mesi.Io.Api.Clipboard.DTO
{
    public class AddClipboardEntryRequest
    {
        public string UserId { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}