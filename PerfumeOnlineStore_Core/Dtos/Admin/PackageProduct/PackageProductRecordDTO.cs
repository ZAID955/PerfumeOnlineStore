using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.PackageProduct
{
    public class PackageProductRecordDTO
    {
        public int? Id { get; set; }
        public string PackageName { get; set; }
        public string ProductName { get; set; }
        public int QuantityForProductInPackage { get; set; }
    }
}
