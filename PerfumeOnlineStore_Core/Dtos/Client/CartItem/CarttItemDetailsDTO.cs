using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Client.CartItem
{
    public class CarttItemDetailsDTO
    {
        public int ItemId { get; set; }
        public int ItemQuantity { get; set; }
        public string? ItemNote { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
    }
}
