using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Abstractions
{
    public interface IShopDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Purchase> Purchases { get; set; }
        DbSet<PurchaseItem> PurchaseItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
