using PerfumeOnlineStore_Core.Dtos.Admin.Package;
using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Client.Cart;
using PerfumeOnlineStore_Core.Dtos.Client.CartItem;
using PerfumeOnlineStore_Core.Dtos.Client.Invoice;
using PerfumeOnlineStore_Core.Dtos.Client.Order;
using PerfumeOnlineStore_Core.Dtos.Client.Review;
using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.IServices
{
    public interface IClientServiceInterface
    {
        #region Account Management
        Task<int> CreateAccountToclient(RegistrationClientDTO dto);
        Task UpdateProfile(UpdateProfileClientDTO dto);
        #endregion

        #region
        Task<int>  CreateCart(int ClientId);
        Task<int> SelectCartItem(SelectItemDTO dto);
        Task<int> SavedCartForLater(int CartId);
        Task<int> CanceledCart(int CartId);
        Task CompletShopping(CompletShoppingDTO dto);
        #endregion

        #region Order Management

        Task<int> CreateOrder(CreateOrUpdateOrderDTO dto);
        Task CreateOrderUser(OrderClientDTO dto);
        Task<PrintInvoiceDTO> PrintInvoice(int orderId);

        #endregion

        #region Review Mangement
        Task CreateReview(CreateOrUpdateReviewDTO dto);
        Task<List<ReviewRecordDTO>> GetReview(int ClientId);
        #endregion


    }
}
