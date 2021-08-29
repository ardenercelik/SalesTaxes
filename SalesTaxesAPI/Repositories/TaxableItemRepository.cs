using Microsoft.EntityFrameworkCore;
using SalesTaxesAPI.Contexts;
using SalesTaxesAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SalesTaxesAPI.Repositories
{
    public class TaxableItemRepository : ITaxableItemRepository
    {
        private readonly TaxableItemContext _context;
        public TaxableItemRepository(TaxableItemContext context)
        {
            _context = context;
        }
        public async Task DeleteItem(TaxableItem item)
        {
            _context.TaxableItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<TaxableItem> GetItem(int id)
        {
            return await _context.TaxableItems.FindAsync(id);
        }

        public async Task<IEnumerable<TaxableItem>> GetItems()
        {
            return await _context.TaxableItems.ToListAsync();
        }

        public async Task PostItem(TaxableItem item)
        {
            _context.TaxableItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Task> PutItem(TaxableItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            try
            {

                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                var taxableItem = await GetItem(item.TaxableItemId);
                if (taxableItem == null)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return Task.CompletedTask;
        }
    }
}
