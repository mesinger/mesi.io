using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mesi.Io.Api.Clipboard.Data;
using Mesi.Io.Api.Clipboard.Models;

namespace Mesi.Io.Api.Clipboard.Domain
{
    public class ClipboardService : IClipboardService
    {
        private readonly IClipboardRepository _clipboardRepository;

        public ClipboardService(IClipboardRepository clipboardRepository)
        {
            _clipboardRepository = clipboardRepository;
        }

        public void AddEntryForUser(Guid userId, string content)
        {
            _clipboardRepository.AddEntry(new ClipboardEntry(userId, content, DateTime.UtcNow));
        }

        public Task<IEnumerable<ClipboardEntry>> GetAllByUserId(Guid userId)
        {
            return _clipboardRepository.GetAllByUserId(userId.ToString());
        }
    }
}