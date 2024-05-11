using PerfumeOnlineStore_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Models.Entites
{
    public class Cart : ParentEntity
    {
        public CartStatus Status { get; set; }
        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
    }
}
