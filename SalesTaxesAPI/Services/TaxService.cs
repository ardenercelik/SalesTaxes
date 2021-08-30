using SalesTaxesAPI.Models;
using System;
namespace SalesTaxesAPI.Services
{
    public class TaxService : ITaxService
    {
        public double CalculateTaxRate(TaxableItemPostDTO taxableItem)
        {
            var isImported = taxableItem.IsImported;
            var isExempt = taxableItem.IsExempt;
            double taxRate = 0.0;

            if (isImported)
            {
                taxRate += 0.05;
            }
            if (!isExempt)
            {
                taxRate += 0.10;
            }
            return Math.Round(taxRate, 2);
        }

        public double CalculateTax(double basePrice, double taxRate)
        {
            double price = basePrice * taxRate;
            var result = Math.Ceiling(price * 20) / 20;
            return result;
        }



    }
}
