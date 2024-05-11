using PerfumeOnlineStore_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Models.Entites
{
    public class UserProduct : ParentEntity
    {
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
