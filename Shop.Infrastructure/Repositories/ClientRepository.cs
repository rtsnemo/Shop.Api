using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Infrastructure.Abstractions;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IShopDbContext _context;

        public ClientRepository(IShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetClientsWithBirthday(DateTime date)
        {
            return await _context.Clients
                .Where(c => c.DateOfBirth.Month == date.Month && c.DateOfBirth.Day == date.Day)
                .ToListAsync();
        }
    }

}
