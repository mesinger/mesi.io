using System.Collections.Generic;
using System.Threading.Tasks;
using Mesi.Io.Domain.Finance.Models;

namespace Mesi.Io.Domain.Finance.Data
{
    /// <summary>
    /// Data access to gold investment entities
    /// </summary>
    public interface IGoldInvestmentRepository
    {
        /// <summary>
        /// Stores a given gold investment
        /// </summary>
        /// <param name="goldInvestment"></param>
        void SaveInvestment(GoldInvestment goldInvestment);

        /// <summary>
        /// Stores a given gold disposal
        /// </summary>
        /// <param name="goldDisposal"></param>
        void SaveDisposal(GoldDisposal goldDisposal);

        /// <summary>
        /// Retrieves all gold investments by a given investor
        /// </summary>
        /// <param name="investor"></param>
        /// <returns></returns>
        Task<IEnumerable<GoldInvestment>> FindAllInvestmentsByInvestor(Investor investor);

        /// <summary>
        /// Retrieves all gold disposals by a given investor
        /// </summary>
        /// <param name="investor"></param>
        /// <returns></returns>
        Task<IEnumerable<GoldDisposal>> FindAllDisposalsByInvestor(Investor investor);
    }
}