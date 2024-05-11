using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Admin.CartItem
{
    public class CreateOrUpdateCartItemDTO
    {
        public int? Id { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
        public int ItemId { get; set; }
        public int CartId { get; set; }
    }
}
