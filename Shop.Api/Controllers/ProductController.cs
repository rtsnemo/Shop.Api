using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces;
using Shop.Application.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("categories/{customerId}")]
        public async Task<IActionResult> GetCategoriesWithPurchasedUnits(int customerId)
        {
            var result = await _productService.GetCategoriesWithPurchasedUnitsAsync(customerId);

            if (result == null || !result.Any())
            {
                return NotFound("No purchases found for this customer.");
            }

            return Ok(result);
        }
    }
}
