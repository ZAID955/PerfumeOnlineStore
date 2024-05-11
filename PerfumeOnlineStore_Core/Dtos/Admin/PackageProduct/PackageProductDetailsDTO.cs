using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Admin.PackageProduct
{
    public class PackageProductDetailsDTO
    {
        public int? Id { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Created { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int QuantityForProductInPackage { get; set; }
    }
}
