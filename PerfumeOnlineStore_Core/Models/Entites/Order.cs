using PerfumeOnlineStore_Core.Models.Shared;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Models.Entites
{
    public class Order : ParentEntity
    {
        public string Title { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public City DeliveryCity { get; set; }
        public string Address { get; set; }
        public float NetPrice { get; set; }
        public float TaxAmount { get; set; }
        public float DelievryPrice { get; set; }
        public float DiscountAmount { get; set; }
        public float TotalPrice { get; set; }
        public PromoCode? PromoCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public OrderStatus Status { get; set; }
        public virtual List<OrderUser> OrderUser { get; set; }
        public string? Note { get; set; }
    }
}

