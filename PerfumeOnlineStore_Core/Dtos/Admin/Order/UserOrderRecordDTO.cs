using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Order
{
    public class UserOrderRecordDTO
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; }
        public int CartId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Created { get; set; }
    }

}
