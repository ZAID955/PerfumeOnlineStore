using PerfumeOnlineStore_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Models.Entites
{
    public class User : ParentEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? Name {  get; set; }
        public int? NationalNo { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyCity { get; set; }
        public string? DeliveryLicenseImageUrl { get; set; }
        public string? DeliveryCar {  get; set; }
        public DateTime? Brithday { get; set; }
        public Gendear? Gendear { get; set; }
        public UserType UserType { get; set; }
        public virtual List<Cart> Carts { get; set; }
        public virtual List<Review> Review { get; set; }
        public virtual List<UserProduct> UserProducts { get; set; }
        public virtual List<OrderUser> OrderUser { get; set; }

    }
}
