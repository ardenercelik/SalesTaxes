using System;
using System.Linq;
using SalesTaxesAPI.Contexts;
using SalesTaxesAPI.Models;
using SalesTaxesAPI.Controllers;
using SalesTaxesAPI.Services;
using SalesTaxesAPI.Repositories;
namespace SalesTaxesAPI.Data
{
    public static class DbInitializer
    {

        
        public async static void Initialize(TaxableItemContext context)
        {
            TaxableItemContext ctx = new TaxableItemContext();
            TaxableItemRepository repo = new TaxableItemRepository(ctx);
            TaxService service = new TaxService();
            TaxableItemsController ct = new TaxableItemsController(repo,service);
            if (context.TaxableItems.Any())
            {
                return;   // DB has been seeded
            }

            var items = new TaxableItemPostDTO[]
            {
                new TaxableItemPostDTO{Name="book",IsExempt=true,IsImported=false, BasePrice = 12.49},
                new TaxableItemPostDTO{Name="music CD",IsExempt=false,IsImported=false, BasePrice=14.99},
                new TaxableItemPostDTO{Name="chocolate bar",IsExempt=true,IsImported=false,BasePrice=0.85},
                new TaxableItemPostDTO{Name="imported box of chocolates",IsExempt=true,IsImported=true, BasePrice=10.00},
                new TaxableItemPostDTO{Name="imported bottle of perfume",IsExempt=false,IsImported=true, BasePrice=47.50},
                new TaxableItemPostDTO{Name="imported bottle of perfume",IsExempt=false,IsImported=true, BasePrice=27.99},
                new TaxableItemPostDTO{Name="bottle of perfume",IsExempt=false,IsImported=false, BasePrice=18.99},
                new TaxableItemPostDTO{Name="packet of headache pills",IsExempt=true,IsImported=false, BasePrice=9.75},
                new TaxableItemPostDTO{Name="box of imported chocolates",IsExempt=true,IsImported=true, BasePrice=11.25},

            };
            foreach (var item in items)
            {
                await ct.PostTaxableItem(item);
            }
           
        }
    }
}
