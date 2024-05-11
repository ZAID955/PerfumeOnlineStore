using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.CartItem
{
    public class CartItemRecordDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public float Price { get; set; }
        public string ItemNote { get; set; }
        public float NetAmountItem { get; set; }
        public int SelectedQuantityOfItem { get; set; }
    }
}
