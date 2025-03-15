using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces;
using Shop.Application.Models.DTO;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("birthday/{monthDay}")]
        public async Task<ActionResult<List<BirthdayClientDto>>> GetClientsWithBirthday(string monthDay)
        {
            if (!DateTime.TryParseExact(monthDay, "MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                return BadRequest("Invalid date format. Use MM-dd.");
            }

            var clients = await _clientService.GetBirthdayClients(date);

            if (clients == null || clients.Count == 0)
            {
                return NotFound("No clients with this birthday today.");
            }

            return Ok(clients);
        }

    }
}
