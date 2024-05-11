using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Order
{
    public class OrderClientDetailsDTO
    {
        public int OrderId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public float NetPrice { get; set; }
        public float TaxAmount { get; set; }
        public float DiscountAmount { get; set; }
        public float TotalPrice { get; set; }
        public string PromoCode { get; set; }
        public string DelievryManPhone { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
