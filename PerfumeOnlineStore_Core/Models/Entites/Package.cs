using PerfumeOnlineStore_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Models.Entites
{
    public class Package : ParentEntity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual List<Review> Review { get; set; }
        public virtual List<PackageProduct> PackageProduct { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
    }
}
