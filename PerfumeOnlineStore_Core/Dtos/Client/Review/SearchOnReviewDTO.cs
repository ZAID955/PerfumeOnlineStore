using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Client.Review
{
    public class SearchOnReviewDTO
    {
        public string? ReviewTitle { get; set; }
        public string? ItemName { get; set; }
        public int? ItemId { get; set; }
        public int? Rating { get; set; }
    }
}
