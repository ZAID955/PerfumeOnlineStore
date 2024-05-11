using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Order
{
    public class OrderRecordDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
