using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Admin.PackageProduct
{
    public class CreateOrUpdatePackageProductDTO
    {
        public int? Id { get; set; }
        public int PackageId { get; set; }
        public int ProductId { get; set; }
        public int QuantityForProductInPackage { get; set; }
    }
}
