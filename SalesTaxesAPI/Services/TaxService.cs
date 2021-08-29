using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTaxesAPI.Services
{
    public class TaxService
    {
        public double CalculateTaxRate()
        {
            return 0.05;
        }

        public double CalculateTax()
        {
            return 14.99;
        }
    }
}
