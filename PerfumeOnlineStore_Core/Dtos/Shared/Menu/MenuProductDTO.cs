using PerfumeOnlineStore_Core.Models.Entites;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Shared.Menu
{
    public class MenuProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public Category Category { get; set; }
        public int TypeId { get; set; }
        public int SectionId { get; set; }
        public int SizeId { get; set; }
        public SizeUnite SizeUnite { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
