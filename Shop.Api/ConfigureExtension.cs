using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Services;
using Shop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Shop.Infrastructure.Abstractions;
using Shop.Application.Interfaces;

namespace Shop.Api
{
    public static class ConfigureExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShopDbContext>(provider => provider.GetRequiredService<ShopDbContext>());

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseService, PurchaseService>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        }
    }
}
