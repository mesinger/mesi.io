using System;
using System.Linq;
using System.Threading.Tasks;
using Mesi.Io.Domain.Finance.Data;
using Mesi.Io.Domain.Finance.Exceptions;
using Mesi.Io.Domain.Finance.Models;

namespace Mesi.Io.Domain.Finance.Service
{
    public class GoldFinanceService : IGoldFinanceService
    {
        private readonly IInvestorRepository _investorRepository;
        private readonly IGoldInvestmentRepository _goldInvestmentRepository;
        private readonly ICurrencyConverter _currencyConverter;

        public GoldFinanceService(IInvestorRepository investorRepository, IGoldInvestmentRepository goldInvestmentRepository, ICurrencyConverter currencyConverter)
        {
            _investorRepository = investorRepository;
            _goldInvestmentRepository = goldInvestmentRepository;
            _currencyConverter = currencyConverter;
        }

        public async Task<GoldInvestment> AddGoldInvestment(string userId, double price, double ounces, string currency, DateTime timeStamp)
        {
            if(price < 0.0) throw new ArgumentException($"Gold investment with price {price} is invalid");
            if(ounces < 0.0) throw new ArgumentException($"Gold investment with {ounces} ounces is invalid");
            if(currency.Length != 3) throw new ArgumentException($"Invalid currency code {currency}");

            var investor = await _investorRepository.FindByUserId(userId);
            if(investor == null) throw new UnknownInvestorException();
            
            var investment = new GoldInvestment(investor, price, currency, ounces, timeStamp);
            _goldInvestmentRepository.SaveInvestment(investment);

            return investment;
        }

        public async Task<GoldDisposal> AddGoldDisposal(string userId, double price, double ounces, string currency, DateTime timeStamp)
        {
            if(price < 0.0) throw new ArgumentException($"Gold disposal with price {price} is invalid");
            if(ounces < 0.0) throw new ArgumentException($"Gold disposal with {ounces} ounces is invalid");
            if(currency.Length != 3) throw new ArgumentException($"Invalid currency code {currency}");
            
            var investor = await _investorRepository.FindByUserId(userId);
            if(investor == null) throw new UnknownInvestorException();
            
            var disposal = new GoldDisposal(investor, price, currency, ounces, timeStamp);
            _goldInvestmentRepository.SaveDisposal(disposal);

            return disposal;
        }

        public async Task<GoldInvestmentOverview> GetInvestmentOverviewForInvestor(string userId, string targetCurrency)
        {
            if(targetCurrency.Length != 3) throw new ArgumentException($"Invalid currency code {targetCurrency}");
            
            var investor = await _investorRepository.FindByUserId(userId);
            if(investor == null) throw new UnknownInvestorException();

            var totalInvestedCapital = _currencyConverter.ConvertAll(
                investor.GoldInvestments.Select(investment => (investment.Price, investment.IsoCurrencySymbol)),
                targetCurrency).Sum();
            
            var totalSoldCapital = _currencyConverter.ConvertAll(
                investor.GoldDisposals.Select(investment => (investment.Price, investment.IsoCurrencySymbol)),
                targetCurrency).Sum();
            
            var overview = new GoldInvestmentOverview(investor, investor.GoldInvestments, investor.GoldDisposals, targetCurrency, totalInvestedCapital, totalSoldCapital);
            return overview;
        }
    }
}