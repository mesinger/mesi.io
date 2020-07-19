using System.Collections.Generic;

namespace Mesi.Io.Domain.Finance.Service
{
    /// <summary>
    /// Provides exchange rates and converts to new currencies
    /// </summary>
    public interface ICurrencyConverter
    {
        /// <summary>
        /// Converts <see cref="value"/> given in currency <see cref="from"/> to currency <see cref="to"/>
        /// </summary>
        /// <param name="value">Money in currency <see cref="from"/></param>
        /// <param name="from">Currency of <see cref="value"/></param>
        /// <param name="to">Target currency</param>
        /// <returns><see cref="value"/> in currency <see cref="to"/></returns>
        double Convert(double value, string from, string to);

        /// <summary>
        /// Provides an exchange rate between two currencies
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        double ExchangeRate(string from, string to);

        /// <summary>
        /// Converts all given value/currency pairs in a given target currency
        /// </summary>
        /// <param name="valueCurrencyPair"></param>
        /// <param name="targetCurrency"></param>
        /// <returns></returns>
        IEnumerable<double> ConvertAll(IEnumerable<(double, string)> valueCurrencyPair, string targetCurrency);
    }
}