using Shop.Application.Models.DTO;
using Shop.Domain.Entities;
using Shop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface IClientService
    {
        Task<List<BirthdayClientDto>> GetBirthdayClients(DateTime date);
    }
}
