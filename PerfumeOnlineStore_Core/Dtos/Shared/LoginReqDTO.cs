using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Shared
{
    public class LoginReqDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
