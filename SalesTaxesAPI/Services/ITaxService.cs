using SalesTaxesAPI.Models;

namespace SalesTaxesAPI.Services
{
    public interface ITaxService
    {
        double CalculateTax(double basePrice, double taxRate);
        double CalculateTaxRate(TaxableItemPostDTO taxableItem);
    }
}