using Microsoft.EntityFrameworkCore;
using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Client.Cart;
using PerfumeOnlineStore_Core.Dtos.Client.CartItem;
using PerfumeOnlineStore_Core.Dtos.Client.Invoice;
using PerfumeOnlineStore_Core.Dtos.Client.Review;
using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.IRepos
{
    public interface IClientReposInterface
    {

        #region Account Management
        Task<int> CreateAccountToclient(RegistrationClientDTO dto);
        Task<int> UpdateProfile(UpdateProfileClientDTO dto);
        Task<User> GetClientById(int ClientId);
        #endregion

        #region 
        Task<int> CreateCart(Cart cart);
        Task<int> CreateCartItem(CartItem cartItem);
        Task<int> SavedCartForLater(Cart cart);
        Task<int> CancelledCart(Cart cart);
        Task CompletedCart(Cart cart);
        Task<Cart> GetCartById(int id);
        #endregion

        #region Order Management

        Task<PromoCode> GetPromoCodeByName(string? PromoCodeName);
        Task<int> CreateOrder(Order order);
        Task<Package> GetPackageById(int id);
        Task<Product> GetProductById(int id);
        Task UpdatePackage(Package package);
        Task UpdateProduct(Product product);
        Task<List<InvoiceItemsDetailsDTO>> GetInvoiceItemsInCart(int orderId);
        Task<PrintInvoiceDTO> PrintInvoice(int orderId);
        Task UpdateOrder(Order order);
        #endregion

        #region Review Mangement
        Task CreateReview(CreateOrUpdateReviewDTO dto);
        Task<List<ReviewRecordDTO>> GetReview(int ClientId);
        #endregion
    }
}
