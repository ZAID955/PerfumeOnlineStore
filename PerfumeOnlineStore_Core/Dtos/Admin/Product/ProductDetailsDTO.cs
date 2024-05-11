using PerfumeOnlineStore_Core.Models.Entites;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Product
{
    public class ProductDetailsDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Section { get; set; }
        public int SizeId { get; set; }
        public string SizeUnite { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int MinQuantity { get; set; }

    }
}
