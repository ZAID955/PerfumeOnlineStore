using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Order
{
    public class OrderItemDTO
    {
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }
        public float ItemQuantity { get; set; }
        public string ItemNote { get; set; }
    }
}
