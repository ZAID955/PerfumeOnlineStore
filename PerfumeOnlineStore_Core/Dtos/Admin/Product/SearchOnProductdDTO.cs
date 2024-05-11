using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.Product
{
    public class SearchOnProductdDTO
    {
        public string? Name { get; set; }
        public int? Brand { get; set; }
        public int? Size { get; set; }
        public float? Price { get; set; }
    }
}
