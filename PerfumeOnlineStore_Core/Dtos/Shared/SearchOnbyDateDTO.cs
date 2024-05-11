using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Shared
{
    public class SearchOnbyDateDTO
    {
        public DateTime? DateTimeFrom { get; set; }
        public DateTime? DateTimeTo { get; set; }
    }
}
