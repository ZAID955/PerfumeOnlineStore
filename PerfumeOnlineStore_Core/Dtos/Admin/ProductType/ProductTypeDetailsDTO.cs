using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Admin.ProductType
{
    public class ProductTypeDetailsDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Name { get; set; }
    }
}
