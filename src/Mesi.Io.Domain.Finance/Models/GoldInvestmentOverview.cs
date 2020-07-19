using System.Collections.Generic;
using System.Linq;

namespace Mesi.Io.Domain.Finance.Models
{
    /// <summary>
    /// Represents an gold investment overview for a specific investor 
    /// </summary>
    public class GoldInvestmentOverview
    {
        public Investor Investor { get; }
        public IEnumerable<GoldInvestment> Investments { get; }
        public IEnumerable<GoldDisposal> Disposals { get; }
        public double TotalInvestedCapital { get; }
        public double TotalInvestedOunces { get; }
        public double TotalSoldCapital { get; }
        public double TotalSoldOunces { get; }
        public double TotalCurrentCapital { get; }
        public double TotalCurrentOunces { get; }
        public string Currency { get; }

        public GoldInvestmentOverview(Investor investor, IEnumerable<GoldInvestment> investments, IEnumerable<GoldDisposal> disposals, string currency, double totalInvestedCapital, double totalSoldCapital)
        {
            Investor = investor;
            Investments = investments;
            Disposals = disposals;
            Currency = currency;
            TotalInvestedCapital = totalInvestedCapital;
            TotalSoldCapital = totalSoldCapital;
            
            TotalCurrentCapital = TotalInvestedCapital - TotalSoldCapital;

            TotalInvestedOunces = investments.Sum(i => i.Ounces);
            TotalSoldOunces = disposals.Sum(d => d.Ounces);
            TotalCurrentOunces = TotalInvestedOunces - TotalSoldOunces;
        }
    }
}