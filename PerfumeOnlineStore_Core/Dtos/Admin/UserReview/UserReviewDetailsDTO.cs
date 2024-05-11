
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Admin.UserReview
{
    public class UserReviewDetailsDTO
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int ClientId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }

    }
}
