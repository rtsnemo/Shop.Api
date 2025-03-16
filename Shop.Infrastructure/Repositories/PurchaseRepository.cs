using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Infrastructure.Abstractions;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly IShopDbContext _context;

        public PurchaseRepository(IShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Purchase>> GetPurchasesByRecentDays(int days)
        {
            var dateThreshold = DateTime.Now.AddDays(-days);

            var purchases = await _context.Purchases
                .Where(p => p.Date >= dateThreshold)
                .Include(p => p.Client)
                .AsNoTracking()
                .ToListAsync();

            return purchases;
        }
    }

}
