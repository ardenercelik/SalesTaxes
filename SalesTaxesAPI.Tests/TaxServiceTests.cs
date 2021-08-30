using SalesTaxesAPI.Services;
using SalesTaxesAPI.Models;
using Xunit;
using System;
namespace SalesTaxesAPI.Tests
{
    
    public class TaxServiceTests
    {
        private TaxService _service = new TaxService();
        [Fact]
        public void ExemptAndImported()
        {

            var item = new TaxableItemPostDTO { Name = "imported box of chocolates", IsExempt = true, IsImported = true, BasePrice = 10.00 };
            double rate = _service.CalculateTaxRate(item);
            Assert.Equal(0.05, rate);
        }
        [Fact]
        public void Exempt()
        {
            var item = new TaxableItemPostDTO { Name = "book", IsExempt = true, IsImported = false, BasePrice = 12.49 };
            double rate = _service.CalculateTaxRate(item);
            Assert.Equal(0.00, rate);
        }
        [Fact]
        public void Imported()
        {
            var item = new TaxableItemPostDTO { Name = "imported bottle of perfume", IsExempt = false, IsImported = true,  BasePrice = 47.50 };
            double rate = _service.CalculateTaxRate(item);
            Assert.Equal(0.15, rate);
        }
        [Fact]
        public void BaseTax()
        {
            var item = new TaxableItemPostDTO { Name = "bottle of perfume", IsExempt = false, IsImported = false, BasePrice = 27.99 };
            double rate = _service.CalculateTaxRate(item);
            Assert.Equal(0.10, rate);
        }

        [Theory]
        [InlineData(12.49, 0.0, 12.49)]
        [InlineData(14.99, 0.10, 16.49)]
        [InlineData(0.85, 0.0, 0.85)]
        [InlineData(10.00, 0.05, 10.50)]
        [InlineData(47.50, 0.15, 54.65)]
        [InlineData(27.99, 0.150, 32.19)]
        [InlineData(18.99, 0.1, 20.89)]
        [InlineData(11.25, 0.05, 11.85)]
        public void CalculateTaxes(double basePrice, double taxRate, double expectedResult)
        {
            var tax = _service.CalculateTax(basePrice, taxRate);
            double result = tax + basePrice;
            result = Math.Round(result, 2);
            Assert.Equal(expectedResult, result);
        }
    }
}
