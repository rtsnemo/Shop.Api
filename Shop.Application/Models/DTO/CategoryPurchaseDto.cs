using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Models.DTO
{
    public class CategoryPurchaseDto
    {
        public string CategoryName { get; set; }
        public int TotalQuantityPurchased { get; set; }
    }
}
