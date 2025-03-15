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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<BirthdayClientDto>> GetBirthdayClients(DateTime date)
        {
            var clients = await _clientRepository.GetClientsWithBirthday(date);
            return clients.Select(c => new BirthdayClientDto
            {
                Id = c.Id,
                FullName = c.FullName
            }).ToList();
        }
    }
}
