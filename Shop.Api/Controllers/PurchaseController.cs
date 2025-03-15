using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces;
using Shop.Application.Models.DTO;
using Shop.Application.Services;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet("recent/{days}")]
        public async Task<ActionResult<List<RecentClientDto>>> GetRecentClients(int days)
        {
            var clients = await _purchaseService.GetRecentClients(days);

            if (clients == null || !clients.Any())
            {
                return NotFound("Clients was not found for this period of time.");
            }

            return Ok(clients);
        }
    }
}
