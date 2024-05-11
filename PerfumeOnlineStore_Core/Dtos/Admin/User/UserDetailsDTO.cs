using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Admin.User
{
    public class UserDetailsDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
    }
}
