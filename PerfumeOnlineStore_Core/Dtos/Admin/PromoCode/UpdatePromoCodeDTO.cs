using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Admin.PromoCode
{
    public class UpdatePromoCodeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float DiscountAmount { get; set; }
        public DateTime DateTimeActive { get; set; }
    }
}
