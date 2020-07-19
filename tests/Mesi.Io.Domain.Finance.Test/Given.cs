using System;
using System.Collections.Generic;
using Mesi.Io.Domain.Finance.Models;

namespace Mesi.Io.Domain.Finance.Test
{
    public static class Given
    {
        public static Investor Investor()
        {
            return new Investor("investor", "1", GoldInvestments(), GoldDisposals());
        } 

        public static IEnumerable<GoldInvestment> GoldInvestments() => new[]
        {
            new GoldInvestment(null, 1500.0, "USD", 1.0, TimeStamp()),
            new GoldInvestment(null, 2500.0, "USD", 2.0, TimeStamp()),
            new GoldInvestment(null, 1500.0, "USD", 1.0, TimeStamp()),
        };
        
        public static IEnumerable<GoldDisposal> GoldDisposals() => new[]
            {new GoldDisposal(null, 1500.0, "USD", 1.0, TimeStamp()), };
        
        public static DateTime TimeStamp() => new DateTime(2020, 1, 1, 0, 0, 0);
    }
}