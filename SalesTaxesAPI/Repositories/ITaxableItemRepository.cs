using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesTaxesAPI.Models;

namespace SalesTaxesAPI.Repositories
{
    public interface ITaxableItemRepository
    {
        Task<IEnumerable<TaxableItem>> GetItems();
        Task<TaxableItem> GetItem(int id);
        Task<Task> PutItem(TaxableItem item);
        Task PostItem(TaxableItem item);
        Task DeleteItem(TaxableItem item);
    }
}
