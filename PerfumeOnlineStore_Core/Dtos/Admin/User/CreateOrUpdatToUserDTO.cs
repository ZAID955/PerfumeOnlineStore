using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Dtos.Admin.User
{
    public class CreateOrUpdatToUserDTO
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string? Name
        {
            get
            {
                return FirstName + " " + SecondName + " " + LastName;
            }
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int UserTypeId { get; set; }
    }
}
