using System.Collections.Generic;
using System.Threading.Tasks;
using Mesi.Io.Api.Clipboard.Models;

namespace Mesi.Io.Api.Clipboard.Data
{
    /// <summary>
    /// Access to clipboard entries
    /// </summary>
    public interface IClipboardRepository
    {
        /// <summary>
        /// Adds a new clipboard entry
        /// </summary>
        /// <param name="entry"></param>
        void AddEntry(ClipboardEntry entry);

        /// <summary>
        /// Retrieves all clipboard entries by a given user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<ClipboardEntry>> GetAllByUserId(string userId);
    }
}