using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Infrastructure.Abstractions;

namespace Shop.Infrastructure.Data
{
    public class ShopDbContext : DbContext, IShopDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PurchaseItem>()
                .HasOne(p => p.Product)
                .WithMany(p => p.PurchaseItems)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<PurchaseItem>()
                .HasOne(p => p.Purchase)
                .WithMany(p => p.PurchaseItems)
                .HasForeignKey(p => p.PurchaseId);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Purchases)
                .HasForeignKey(p => p.ClientId);

            modelBuilder.Entity<Product>()
               .HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Purchase>()
                .Property(p => p.TotalAmount)
                .HasColumnType("decimal(18,2)");

    }
}

}