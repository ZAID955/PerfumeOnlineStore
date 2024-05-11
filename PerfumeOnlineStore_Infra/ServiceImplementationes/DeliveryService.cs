using PerfumeOnlineStore_Core.Dtos.Delivery;
using PerfumeOnlineStore_Core.Dtos.Supplier;
using PerfumeOnlineStore_Core.Helper.Enums;
using PerfumeOnlineStore_Core.IRepos;
using PerfumeOnlineStore_Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Infra.ServiceImplementation
{
    public class DeliveryService : IDeliveryServiceInterface
    {
        private readonly IDeliveryReposInterface _repos;
        public DeliveryService(IDeliveryReposInterface repos)
        {
            _repos = repos;
        }
        
        #region Account Management
        public async Task<int> CreateAccountToDelivery(RegistrationDeliveryDTO dto)
        {
            return await _repos.CreateAccountToDelivery(dto);
        }

        public async Task UpdateProfile(UpdateProfileDeliveryDTO dto)
        {
            await _repos.UpdateProfile(dto);
        }
        #endregion
    }
}
