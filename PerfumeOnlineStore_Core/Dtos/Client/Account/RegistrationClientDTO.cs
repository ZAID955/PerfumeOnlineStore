using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Client.Account
{
    public class RegistrationClientDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime? Brithday { get; set; }
        public Gendear? Gendear { get; set; }
        public string Name
        {
            get
            {
                return FirstName + " " + SecondName + " " + LastName;
            }
        }

    }
}
