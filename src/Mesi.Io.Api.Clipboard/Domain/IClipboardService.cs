using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mesi.Io.Api.Clipboard.Models;

namespace Mesi.Io.Api.Clipboard.Domain
{
    /// <summary>
    /// Performs operations on user clipboard entries
    /// </summary>
    public interface IClipboardService
    {
        /// <summary>
        /// Adds a new clipboard entry for the user with given id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="content"></param>
        void AddEntryForUser(Guid userId, string content);

        /// <summary>
        /// Retrieves all clipboard entries for a given user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<ClipboardEntry>> GetAllByUserId(Guid userId);
    }
}