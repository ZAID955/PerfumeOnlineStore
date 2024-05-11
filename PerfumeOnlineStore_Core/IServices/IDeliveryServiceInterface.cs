using PerfumeOnlineStore_Core.Dtos.Delivery;

namespace PerfumeOnlineStore_Core.IServices
{
    public interface IDeliveryServiceInterface
    {
        #region Account Management
        Task<int> CreateAccountToDelivery(RegistrationDeliveryDTO dto);
        Task UpdateProfile(UpdateProfileDeliveryDTO dto);
        #endregion

    }
}
