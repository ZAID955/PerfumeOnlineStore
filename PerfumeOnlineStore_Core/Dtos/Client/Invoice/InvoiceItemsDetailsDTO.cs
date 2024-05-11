namespace PerfumeOnlineStore_Core.Dtos.Client.Invoice
{
    public class InvoiceItemsDetailsDTO
    {
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public float ItemPricePerUnit { get; set; }
        public string? ItemNote { get; set; }
        public float Price { get; set; }
    }
}
