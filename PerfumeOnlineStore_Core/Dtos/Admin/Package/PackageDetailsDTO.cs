using PerfumeOnlineStore_Core.Models.Shared;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Package
{
    public class PackageDetailsDTO : ParentEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
