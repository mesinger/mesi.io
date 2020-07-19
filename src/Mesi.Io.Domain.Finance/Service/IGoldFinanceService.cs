using System;
using System.Threading.Tasks;
using Mesi.Io.Domain.Finance.Models;

namespace Mesi.Io.Domain.Finance.Service
{
    /// <summary>
    /// Access to gold investments for specific investors
    /// </summary>
    public interface IGoldFinanceService
    {
        /// <summary>
        /// Stores a new investment entry for a investor
        /// </summary>
        /// <param name="userId">The user id of the investor</param>
        /// <param name="price"></param>
        /// <param name="ounces"></param>
        /// <param name="currency"></param>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        Task<GoldInvestment> AddGoldInvestment(string userId, double price, double ounces, string currency, DateTime timeStamp);
        
        /// <summary>
        /// Stores a new disposal entry for a investor
        /// </summary>
        /// <param name="userId">The user id of the investor</param>
        /// <param name="price"></param>
        /// <param name="ounces"></param>
        /// <param name="currency"></param>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        Task<GoldDisposal> AddGoldDisposal(string userId, double price, double ounces, string currency, DateTime timeStamp);

        /// <summary>
        /// Retrieves the gold investment overview for a given investor in given currency
        /// </summary>
        /// <param name="userId">The userid of the investor</param>
        /// <param name="targetCurrency"></param>
        /// <returns></returns>
        Task<GoldInvestmentOverview> GetInvestmentOverviewForInvestor(string userId, string targetCurrency);
    }
}