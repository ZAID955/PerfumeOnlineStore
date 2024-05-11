using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Supplier
{
    public class RegistrationSupplierDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyCity { get; set; }
    }
}
