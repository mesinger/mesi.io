using System;

namespace Mesi.Io.Domain.Finance.Models
{
    /// <summary>
    /// Represents a gold investment done by a investor
    /// </summary>
    public class GoldInvestment
    {
        public Investor Investor { get; }
        public double Price { get; }
        public string IsoCurrencySymbol { get; }
        public double Ounces { get; }
        public DateTime TimeStamp { get; }

        public GoldInvestment(Investor investor, double price, string isoCurrencySymbol, double ounces, DateTime timeStamp)
        {
            Investor = investor;
            Price = price;
            IsoCurrencySymbol = isoCurrencySymbol;
            Ounces = ounces;
            TimeStamp = timeStamp;
        }
    }
}