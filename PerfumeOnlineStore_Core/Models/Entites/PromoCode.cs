using PerfumeOnlineStore_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Models.Entites
{
    public class PromoCode : ParentEntity
    {
        public string Name { get; set; }
        public float DiscountAmount { get; set; }
        public DateTime DateTimeActive { get; set; }
    }
}
