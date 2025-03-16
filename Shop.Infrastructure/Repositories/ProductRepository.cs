using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Infrastructure.Abstractions;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IShopDbContext _context;

        public ProductRepository(IShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<PurchaseItem>> GetPurchaseItemsByCustomerIdAsync(int customerId)
        {
            var purchaseItems = await _context.PurchaseItems
                .Where(pi => pi.Purchase.ClientId == customerId)
                .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
                .AsNoTracking()
                .ToListAsync();

            return purchaseItems;
        }

    }

}
