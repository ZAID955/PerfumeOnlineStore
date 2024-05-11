using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Package
{
    public class PackageRecordDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
