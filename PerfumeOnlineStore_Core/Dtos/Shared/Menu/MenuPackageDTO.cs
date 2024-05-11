using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Shared.Menu
{
    public class MenuPackageDTO
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
