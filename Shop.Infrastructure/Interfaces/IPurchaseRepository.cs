using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GetPurchasesByRecentDays(int days);
    }
}
