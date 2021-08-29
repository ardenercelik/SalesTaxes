﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTaxesAPI.Contexts;
using SalesTaxesAPI.Models;
using SalesTaxesAPI.Repositories;
namespace SalesTaxesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxableItemsController : ControllerBase
    {
        ITaxableItemRepository _repository;

        public TaxableItemsController(ITaxableItemRepository repository)
        {
            _repository = repository;
        }

        // GET: api/TaxableItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxableItem>>> GetTaxableItems()
        {
            var response = await _repository.GetItems();
            return Ok(response);
        }

        // GET: api/TaxableItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxableItem>> GetTaxableItem(int id)
        {
            var taxableItem = await _repository.GetItem(id);

            if (taxableItem == null)
            {
                return NotFound();
            }

            return Ok(taxableItem);
        }

        // PUT: api/TaxableItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxableItem(int id, TaxableItem taxableItem)
        {
            if (id != taxableItem.TaxableItemId)
            {
                return BadRequest();
            }

            var result = await _repository.PutItem(taxableItem);
            if (result == null)
            {
                return NotFound();
            } 

            return NoContent();
        }

        // POST: api/TaxableItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaxableItem>> PostTaxableItem(TaxableItemPostDTO taxableItem)
        {
            var item = new TaxableItem()
            {
                IsImported = taxableItem.IsImported,
                IsExempt = taxableItem.IsExempt,
                Name = taxableItem.Name,
                TaxRate = 0.05
            };
            await _repository.PostItem(item);

            return Ok();
        }

        // DELETE: api/TaxableItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxableItem(int id)
        {
            var taxableItem = await _repository.GetItem(id);
            if (taxableItem == null)
            {
                return NotFound();
            }

            await _repository.DeleteItem(taxableItem);

            return NoContent();
        }
    }
}
