using System;

namespace Mesi.Io.Domain.Finance.Models
{
    /// <summary>
    /// Represents a gold disposal from a investor
    /// </summary>
    public class GoldDisposal
    {
        public Investor Investor { get; }
        public double Price { get; }
        public string IsoCurrencySymbol { get; }
        public double Ounces { get; }
        public DateTime TimeStamp { get; }

        public GoldDisposal(Investor investor, double price, string isoCurrencySymbol, double ounces, DateTime timeStamp)
        {
            Investor = investor;
            Price = price;
            IsoCurrencySymbol = isoCurrencySymbol;
            Ounces = ounces;
            TimeStamp = timeStamp;
        }
    }
}