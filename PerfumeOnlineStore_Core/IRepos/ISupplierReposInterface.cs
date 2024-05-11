using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Supplier;
using PerfumeOnlineStore_Core.Models.Entites;

namespace PerfumeOnlineStore_Core.IRepos
{
    public interface ISupplierReposInterface
    {
        #region Account Management
        Task<int> CreateAccountToSupplier(RegistrationSupplierDTO dto);
        Task<int> Login(LoginDTO dto);
        Task<int> UpdateProfile(UpdateProfileSupplierDTO dto);
        Task<User> GetSupplierById(int SupplierId);
        #endregion
    }
}
