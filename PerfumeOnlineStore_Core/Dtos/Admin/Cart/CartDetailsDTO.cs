using PerfumeOnlineStore_Core.Dtos.Admin.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Cart
{
    public class CartDetailsDTO
    {
        public int CartId { get; set; }
        public string ClientName { get; set; }
        public List<CartItemRecordDTO> Items { get; set; }
        public int Quntity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
