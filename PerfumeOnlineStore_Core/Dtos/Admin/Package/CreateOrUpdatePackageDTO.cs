using PerfumeOnlineStore_Core.Models.Entites;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Package
{
    public class CreateOrUpdatePackageDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public Category Category { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
