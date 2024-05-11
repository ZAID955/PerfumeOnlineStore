using PerfumeOnlineStore_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Models.Entites
{
    public class Review : ParentEntity
    {
        public string Title { get; set; }
        public virtual Package? Package { get; set; }
        public virtual Product? Product { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public virtual User User { get; set; }
    }
}
