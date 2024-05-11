using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Client.CartItem
{
    public class SelectItemDTO
    {
        public int ItemId { get; set; }
        public int ItemQuantity { get; set; }
        public string? ItemNote { get; set; }
    }
}
