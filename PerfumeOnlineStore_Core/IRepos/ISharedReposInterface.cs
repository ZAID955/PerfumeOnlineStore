using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;
using PerfumeOnlineStore_Core.Models.Entites;
using PerfumeOnlineStore_Core.Dtos.Shared;

namespace PerfumeOnlineStore_Core.IRepos
{
    public interface ISharedReposInterface
    {
        #region
        Task ResetPassword(UpdatePasswordDTO dto);
        #endregion
        /*
        //ViewMenu
        Task<MenuItemtDTO> ViewMenuItemDTO(int menuItemId, bool isItem = true);

        //Mange Cart Item and Selection 
        Task AddItemsInCart(int cartId, int itemid, int qtn, string note);
        Task UpdateItemsInCart(int cartItemId, int qtn, string note);
        Task DeleteItemsInCart(int cartItemId);

        #region Product
        Task<List<ProductRecordDTO>> GetProductsByCategory(Category category);
        Task<List<ProductRecordDTO>> GetProductsByBrand(string brandName);
        Task<List<ProductRecordDTO>> GetProductsBySection(string sectionName);
        Task<List<ProductRecordDTO>> GetProductsByType(string typeName);
        #endregion

        #region
        Task<List<Review>> GetReviewsByProduct(int productId);
        Task<List<Review>> GetReviewsByClient(int clientId);
        Task<List<CartItem>> GetCartItems(int cartId);
        Task<List<Order>> GetOrdersByClientId(int clientId);
        Task<List<CartRecordDTO>> GetCartByClientId(int clientId);
        Task<List<Order>> GetOrdersByClientName(string clientName);
        Task<OrderRecordDTO> GetOrdersByClientAndStatus(int clientId, OrderStatus status);
        Task<List<OrderRecordDTO>> GetOrdersByClientAndDateRange(int clientId, DateTime startDate, DateTime endDate);
        Task<List<OrderRecordDTO>> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
        Task<List<OrderRecordDTO>> GetOrdersByDeliveryMan(string deliveryManPhone);
        Task<List<OrderRecordDTO>> GetOrdersByPaymentMethod(PaymentMethod paymentMethod);
        Task<List<Order>> GetOrdersWithPromoCode();
        #endregion
        */
    }
}
