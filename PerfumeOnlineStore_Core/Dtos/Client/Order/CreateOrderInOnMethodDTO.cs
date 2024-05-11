using PerfumeOnlineStore_Core.Dtos.Client.CartItem;
using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Client.Order
{
    public class CreateOrderInOnMethodDTO
    {
        public int? Id { get; set; }
        public City DeliveryCity { get; set; }
        public string Address { get; set; }
        public float NetPrice { get; set; }
        public float TaxAmount { get; set; } = 0.16f;
        public float DiscountAmount { get; set; }
        public PromoCode? PromoCode { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Note { get; set; }
        public virtual List<SelectItemDTO> selectItem { get; set; }
    }
}
