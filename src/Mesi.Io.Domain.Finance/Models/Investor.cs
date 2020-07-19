using System.Collections.Generic;

namespace Mesi.Io.Domain.Finance.Models
{
    /// <summary>
    /// Represents an investor
    /// </summary>
    public class Investor
    {
        public string Name { get; }
        public string UserId { get; }
        public IEnumerable<GoldInvestment> GoldInvestments { get; }
        public IEnumerable<GoldDisposal> GoldDisposals { get; }

        public Investor(string name, string userId, IEnumerable<GoldInvestment> goldInvestments, IEnumerable<GoldDisposal> goldDisposals)
        {
            Name = name;
            UserId = userId;
            GoldInvestments = goldInvestments;
            GoldDisposals = goldDisposals;
        }
    }
}