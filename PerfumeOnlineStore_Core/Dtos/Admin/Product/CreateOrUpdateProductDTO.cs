
using PerfumeOnlineStore_Core.Models.Entites;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Product
{
    public class CreateOrUpdateProductDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Category Category { get; set; }
        public int TypeId { get; set; }
        public int SectionId { get; set; }
        public int SizeId { get; set; }
        public SizeUnite SizeUnite { get; set; }
        public int NewQuantity { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public bool? IsActive { get; set; }
        public int MinQuantity { get; set; }

    }
}
