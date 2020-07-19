using System;
using System.Collections.Generic;
using System.Linq;
using Mesi.Io.Domain.Finance.Data;
using Mesi.Io.Domain.Finance.Exceptions;
using Mesi.Io.Domain.Finance.Models;
using Mesi.Io.Domain.Finance.Service;
using Moq;
using Xunit;

namespace Mesi.Io.Domain.Finance.Test
{
    public class GoldFinanceServiceTest
    {
        private readonly IGoldFinanceService sut;
        private readonly Mock<IInvestorRepository> _investorRepository;
        private readonly Mock<IGoldInvestmentRepository> _investmentRepository;
        private readonly Mock<ICurrencyConverter> _currencyConverter;

        public GoldFinanceServiceTest()
        {
            _investorRepository = new Mock<IInvestorRepository>();
            _investmentRepository = new Mock<IGoldInvestmentRepository>();
            _currencyConverter = new Mock<ICurrencyConverter>();
            sut = new GoldFinanceService(_investorRepository.Object, _investmentRepository.Object,
                _currencyConverter.Object);
        }

        [Fact]
        public async void ItShallAddGoldInvestment()
        {
            // Given
            var userId = "1";
            var investor = Given.Investor();

            _investorRepository.Setup(repo => repo.FindByUserId(userId)).ReturnsAsync(investor);

            // When
            var price = 1000.0;
            var ounce = 1.0;
            var currency = "EUR";
            var timeStamp = Given.TimeStamp();

            var actual = await sut.AddGoldInvestment(userId, price, ounce, currency, timeStamp);

            // Then
            var expected = new GoldInvestment(investor, price, currency, ounce, timeStamp);
            Assert.Equal(expected.Investor.UserId, actual.Investor.UserId);
            Assert.Equal(expected.Price, actual.Price);
            Assert.Equal(expected.IsoCurrencySymbol, actual.IsoCurrencySymbol);
            Assert.Equal(expected.Ounces, actual.Ounces);
            _investmentRepository.Verify(repo => repo.SaveInvestment(actual), Times.Once);
        }
        
        [Fact]
        public async void ItShallAddGoldDisposal()
        {
            // Given
            var userId = "1";
            var investor = Given.Investor();

            _investorRepository.Setup(repo => repo.FindByUserId(userId)).ReturnsAsync(investor);

            // When
            var price = 1000.0;
            var ounce = 1.0;
            var currency = "EUR";
            var timeStamp = Given.TimeStamp();

            var actual = await sut.AddGoldDisposal(userId, price, ounce, currency, timeStamp);

            // Then
            var expected = new GoldDisposal(investor, price, currency, ounce, timeStamp);
            Assert.Equal(expected.Investor.UserId, actual.Investor.UserId);
            Assert.Equal(expected.Price, actual.Price);
            Assert.Equal(expected.IsoCurrencySymbol, actual.IsoCurrencySymbol);
            Assert.Equal(expected.Ounces, actual.Ounces);
            _investmentRepository.Verify(repo => repo.SaveDisposal(actual), Times.Once);
        }

        [Fact]
        public async void ItShallCreateInvestmentOverview()
        {
            // Given
            var userId = "1";
            var targetCurrency = "EUR";
            var investor = Given.Investor();

            _investorRepository.Setup(repo => repo.FindByUserId(userId)).ReturnsAsync(investor);
            _currencyConverter
                .Setup(converter => converter.ConvertAll(It.IsAny<IEnumerable<(double, string)>>(), targetCurrency))
                .Returns(Enumerable.Empty<double>());
            
            // When
            var actual = await sut.GetInvestmentOverviewForInvestor(userId, targetCurrency);
            
            // Then
            var expected = new GoldInvestmentOverview(investor, investor.GoldInvestments, investor.GoldDisposals, targetCurrency, 0, 0);
            Assert.Equal(expected.Investor.UserId, actual.Investor.UserId);
            Assert.Equal(expected.Currency, actual.Currency);
            Assert.Equal(expected.Investments.Select(i => i.Ounces).Sum(), actual.Investments.Select(i => i.Ounces).Sum());
            Assert.Equal(expected.Disposals.Select(d => d.Ounces).Sum(), actual.Disposals.Select(d => d.Ounces).Sum());
            Assert.Equal(expected.TotalInvestedOunces, actual.TotalInvestedOunces);
            Assert.Equal(expected.TotalSoldOunces, actual.TotalSoldOunces);
            Assert.Equal(expected.TotalCurrentOunces, actual.TotalCurrentOunces);
        }

        [Fact]
        public void ItShallThrowForUnknownInvestor()
        {
            // Given
            var userId = "1";
            _investorRepository.Setup(repo => repo.FindByUserId(userId));

            // Then
            Assert.ThrowsAsync<UnknownInvestorException>(() =>
                sut.AddGoldInvestment(userId, 1500.0, 1.0, "EUR", Given.TimeStamp()));
            Assert.ThrowsAsync<UnknownInvestorException>(() =>
                sut.AddGoldDisposal(userId, 1500.0, 1.0, "EUR", Given.TimeStamp()));
            Assert.ThrowsAsync<UnknownInvestorException>(() => sut.GetInvestmentOverviewForInvestor(userId, "EUR"));
        }

        [Fact]
        public void ItShallThrowForNegativePrice()
        {
            // Given
            var userId = "1";
            var investor = Given.Investor();

            _investorRepository.Setup(repo => repo.FindByUserId(userId)).ReturnsAsync(investor);

            // Then
            Assert.ThrowsAsync<ArgumentException>(() =>
                sut.AddGoldInvestment(userId, -1.0, 1.0, "EUR", Given.TimeStamp()));
            Assert.ThrowsAsync<ArgumentException>(() =>
                sut.AddGoldInvestment(userId, -1.0, 1.0, "EUR", Given.TimeStamp()));
        }

        [Fact]
        public void ItShallThrowForNegativeOunces()
        {
            // Given
            var userId = "1";
            var investor = Given.Investor();

            _investorRepository.Setup(repo => repo.FindByUserId(userId)).ReturnsAsync(investor);

            // Then
            Assert.ThrowsAsync<ArgumentException>(() =>
                sut.AddGoldInvestment(userId, 1500.0, -1.0, "EUR", Given.TimeStamp()));
            Assert.ThrowsAsync<ArgumentException>(() =>
                sut.AddGoldInvestment(userId, 1500.0, -1.0, "EUR", Given.TimeStamp()));
        }

        [Fact]
        public void ItShallThrowForInvalidCurrency()
        {
            // Given
            var userId = "1";
            var investor = Given.Investor();

            _investorRepository.Setup(repo => repo.FindByUserId(userId)).ReturnsAsync(investor);

            // Then
            Assert.ThrowsAsync<ArgumentException>(() =>
                sut.AddGoldInvestment(userId, 1500.0, 1.0, "EURX", Given.TimeStamp()));
            Assert.ThrowsAsync<ArgumentException>(() =>
                sut.AddGoldInvestment(userId, 1500.0, 1.0, "EURX", Given.TimeStamp()));
            Assert.ThrowsAsync<ArgumentException>(() =>
                sut.GetInvestmentOverviewForInvestor(userId, "ADUS"));
        }
    }
}