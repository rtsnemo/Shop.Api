using Shop.Application.Interfaces;
using Shop.Application.Models.DTO;
using Shop.Domain.Entities;
using Shop.Infrastructure.Interfaces;
using Shop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<CategoryPurchaseDto>> GetCategoriesWithPurchasedUnitsAsync(int customerId)
        {
            var purchaseItems = await _productRepository.GetPurchaseItemsByCustomerIdAsync(customerId);

            var categoryPurchaseInfo = purchaseItems
                .GroupBy(pi => pi.Product.Category.Name)
                .Select(g => new CategoryPurchaseDto
                {
                    CategoryName = g.Key,
                    TotalQuantityPurchased = g.Sum(pi => pi.Quantity)
                })
                .ToList();

            return categoryPurchaseInfo;
        }
    }
}
