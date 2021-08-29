using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesTaxesAPI.Contexts;
using SalesTaxesAPI.Models;
namespace SalesTaxesAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TaxableItemContext context)
        {
            // Look for any students.
            //if (context.TaxableItems.Any())
            //{
            //    return;   // DB has been seeded
            //}

            var items = new TaxableItem[]
            {
                new TaxableItem{Name="book",IsExempt=true,IsImported=false,TaxRate=0.0, BasePrice=12.49},
                new TaxableItem{Name="music CD",IsExempt=false,IsImported=false,TaxRate=0.10, BasePrice=14.99},
                new TaxableItem{Name="chocolate bar",IsExempt=true,IsImported=false,TaxRate=0, BasePrice=0.85},
                new TaxableItem{Name="imported box of chocolates",IsExempt=true,IsImported=true,TaxRate=0.05, BasePrice=10.00},
                new TaxableItem{Name="imported bottle of perfume",IsExempt=false,IsImported=true,TaxRate=0.15, BasePrice=47.50},
                new TaxableItem{Name="bottle of perfume",IsExempt=false,IsImported=false,TaxRate=0.10, BasePrice=27.99},
                new TaxableItem{Name="packet of headache pills",IsExempt=true,IsImported=false,TaxRate=0.0, BasePrice=9.75},
                new TaxableItem{Name="box of imported chocolates",IsExempt=true,IsImported=false,TaxRate=0.05, BasePrice=11.25}
            };

            context.TaxableItems.AddRange(items);
            context.SaveChanges();

           
        }
    }
}
