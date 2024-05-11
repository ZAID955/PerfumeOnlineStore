using PerfumeOnlineStore_Core.Dtos.Client.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Client.Cart
{
    public class CreateCartDTO
    {
        public List<SelectItemDTO> Items { get; set; }
        public int ClientId { get; set; }
    }
}
