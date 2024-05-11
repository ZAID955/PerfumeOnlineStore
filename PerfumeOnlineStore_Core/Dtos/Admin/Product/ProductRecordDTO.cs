using PerfumeOnlineStore_Core.Models.Entites;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Product
{
    public class ProductRecordDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ImageUrl { get; set; }
        public int Size { get; set; }
        public string SizeUnite { get; set; }
        public float Price { get; set; }

    }
}
