using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Admin.ProductSize
{
    public class ProductSizeDetailsDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int Size { get; set; }
    }
}
