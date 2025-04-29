using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyFastDTO
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } // Optional, for display
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
