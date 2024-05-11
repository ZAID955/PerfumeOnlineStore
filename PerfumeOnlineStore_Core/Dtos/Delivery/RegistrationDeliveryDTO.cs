using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Delivery
{
    public class RegistrationDeliveryDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Name
        {
            get
            {
                return FirstName + " " + SecondName + " " + LastName;
            }
        }
        public int NationalNo { get; set; }
        public string DeliveryLicenseImageUrl { get; set; }
        public string DeliveryCar { get; set; }
        public DateTime Brithday { get; set; }
        public Gendear Gendear { get; set; }
    }
}
