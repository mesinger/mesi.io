using System.Threading.Tasks;
using Mesi.Io.Domain.Finance.Models;

namespace Mesi.Io.Domain.Finance.Data
{
    /// <summary>
    /// Data access to investors
    /// </summary>
    public interface IInvestorRepository
    {
        /// <summary>
        /// Saves a new investor
        /// </summary>
        /// <param name="investor"></param>
        void Save(Investor investor);

        /// <summary>
        /// Finds a investor by a given userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Investor?> FindByUserId(string userId);
    }
}