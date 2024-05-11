using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Supplier;
using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.IServices
{
    public interface ISupplierServiceInterface
    {
        #region Account Management
        Task<int> CreateAccountToSupplier(RegistrationSupplierDTO dto);
        Task<int> UpdateProfile(UpdateProfileSupplierDTO dto);
        #endregion
    }
}
