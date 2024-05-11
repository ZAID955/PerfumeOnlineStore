using PerfumeOnlineStore_Core.Dtos.Supplier;
using PerfumeOnlineStore_Core.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Infra.ServiceImplementationes
{
    public class SupplierService
    {
        private readonly ISupplierReposInterface _repos;
        public SupplierService(ISupplierReposInterface repos)
        {
            _repos = repos;
        }
        #region Account Management
        public async Task<int> CreateAccountToSupplier(RegistrationSupplierDTO dto)
        {
            return await _repos.CreateAccountToSupplier(dto);
        }

        public async Task UpdateProfile(UpdateProfileSupplierDTO dto)
        {
            await _repos.UpdateProfile(dto);
        }
        #endregion
    }
}
