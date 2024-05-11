using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Cart
{
    public class UpdateCartDTO
    {
        public int ItemId { get; set; }
        public int Quntity { get; set; }
    }
}
