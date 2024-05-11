using PerfumeOnlineStore_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Models.Entites
{
    public class PackageProduct : ParentEntity
    {
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Package Package { get; set; }
    }
}
