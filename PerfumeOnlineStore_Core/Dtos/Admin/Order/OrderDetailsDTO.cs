using PerfumeOnlineStore_Core.Dtos.Client;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Order
{
    public class OrderDetailssDTO
    {
        public int OrderId { get; set; }
        public bool IsActive { get; set; }
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
        public DateTime OrderDate { get; set; }
        public string Note { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string clinetPhoneNumber { get; set; }
        public string UserName { get; set; }
        public int CartId { get; set; }

    }
}
