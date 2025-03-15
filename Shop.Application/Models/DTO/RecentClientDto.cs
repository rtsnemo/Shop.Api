using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Models.DTO
{
    public class RecentClientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime LastPurchaseDate { get; set; }
    }
}
