using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Client.Review
{
    public class CreateOrUpdateReviewDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ItemId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int clientId { get; set; }
    }
}
