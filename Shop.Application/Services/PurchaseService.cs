using Shop.Application.Interfaces;
using Shop.Application.Models.DTO;
using Shop.Domain.Entities;
using Shop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<List<RecentClientDto>> GetRecentClients(int days)
        {
            var purchases = await _purchaseRepository.GetPurchasesByRecentDays(days);

            var recentClients = purchases
                .GroupBy(p => p.Client)
                .Select(g => new RecentClientDto
                {
                    Id = g.Key.Id,
                    FullName = g.Key.FullName,
                    LastPurchaseDate = g.Max(p => p.Date)
                })
                .ToList();

            return recentClients;
        }
    }
}
