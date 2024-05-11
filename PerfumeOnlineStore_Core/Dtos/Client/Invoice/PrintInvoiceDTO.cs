using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Client.Invoice
{
    public class PrintInvoiceDTO
    {
        public string InvoiceTitle { get; set; }
        public int OrderId { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public float NetPrice { get; set; }
        public float TaxAmount { get; set; }
        public float DelievryPrice { get; set; }
        public float DiscountAmount { get; set; }
        public float TotalPrice { get; set; }
        public List<InvoiceItemsDetailsDTO> ItemsDetails { get; set; }


    }
}
