
using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Delivery;
using PerfumeOnlineStore_Core.Dtos.Supplier;
using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.IRepos
{
    public interface IDeliveryReposInterface
    {
        #region Account Management
        Task<int> CreateAccountToDelivery(RegistrationDeliveryDTO dto);
        Task<int> Login(LoginDTO dto);
        Task<int> UpdateProfile(UpdateProfileDeliveryDTO dto);
        Task<User> GetDeliveryById(int DeliveryId);
        #endregion
        /*
        #region Account
        Task ResetPassword(UpdatePasswordDTO dto);
        Task UpdateProfile(UpdateProfileDTO dto);
        #endregion
        #region Order Management
        Task UpdateOrderStatus(int orderId, OrderStatus status);
        #endregion
        */
    }
}
