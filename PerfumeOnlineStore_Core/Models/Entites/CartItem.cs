using PerfumeOnlineStore_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Models.Entites
{
    public class CartItem : ParentEntity
    {
        public int Quantity { get; set; }
        public string? Note { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Package? Package { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
