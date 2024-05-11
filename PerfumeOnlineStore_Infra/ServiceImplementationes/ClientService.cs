using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Client.Cart;
using PerfumeOnlineStore_Core.Dtos.Client.CartItem;
using PerfumeOnlineStore_Core.Dtos.Client.Invoice;
using PerfumeOnlineStore_Core.Dtos.Client.Order;
using PerfumeOnlineStore_Core.Dtos.Client.Review;
using PerfumeOnlineStore_Core.IRepos;
using PerfumeOnlineStore_Core.IServices;
using PerfumeOnlineStore_Core.Models.Entites;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Infra.ServiceImplementation
{
    public class ClientService : IClientServiceInterface
    {
        private readonly IClientReposInterface _repos;
        public ClientService(IClientReposInterface repos)
        {
            _repos = repos;
        }

        #region Account Management
        public Task<int> CreateAccountToclient(RegistrationClientDTO dto)
        {
            return _repos.CreateAccountToclient(dto);
        }

        public async Task UpdateProfile(UpdateProfileClientDTO dto)
        {
            await _repos.UpdateProfile(dto);
        }
        #endregion

        #region Cart Mangement
        public async Task<int> CreateCart(int clientId)
        {
            var cart = new Cart
            {
                User = await _repos.GetClientById(clientId),
                Status = CartStatus.Processing
             };

            return await _repos.CreateCart(cart);
        }
        public async Task<int> SelectCartItem(SelectItemDTO dto)
        {
            var carItem = new CartItem
            {
                Package = await _repos.GetPackageById(dto.ItemId),
                Product = await _repos.GetProductById(dto.ItemId),
                Quantity = dto.ItemQuantity,
                Note = dto.ItemNote,
            };

            return await _repos.CreateCartItem(carItem);
        }
        public async Task<int> SavedCartForLater(int CartId)
        {
            var existingCart = new Cart
            {
                Id = CartId,
                Status = CartStatus.SavedForLater,
            };

            return await _repos.SavedCartForLater(existingCart);
        }
        public async Task<int> CanceledCart(int CartId)
        {
            var existingCart = new Cart
            {
                Id = CartId,
                Status = CartStatus.Cancelled,
            };

            return await _repos.CancelledCart(existingCart);
        }
        public async Task CompletShopping(CompletShoppingDTO dto)
        {
            var netPrice = 0f;
            var cart = await _repos.GetCartById(dto.CartId);
            if (cart.CartItems == null)
            {
                netPrice = 0;
            }
            else
            {
                foreach (var n in cart.CartItems)
                {
                    var package = n.Package;
                    var product = n.Product;
                    if (package != null)
                    {
                        if (package.Quantity < n.Quantity)
                        {
                            throw new ArgumentException("out of stock");
                        }
                        else
                        {
                            package.Quantity -= n.Quantity;
                            netPrice += (n.Quantity * package.Price);
                            var existingpackage = new Package
                            {
                                Id = package.Id,
                                Quantity = package.Quantity
                            };
                            await _repos.UpdatePackage(existingpackage);
                        }
                    }
                    else if (product != null)
                    {
                        if (product.Quantity < n.Quantity)
                        {
                            throw new ArgumentException("out of stock");
                        }
                        else
                        {
                            product.Quantity -= n.Quantity;
                            netPrice += (n.Quantity * product.Price);
                            var existingproduct = new Product
                            {
                                Id = product.Id,
                                Quantity = product.Quantity
                            };
                            await _repos.UpdateProduct(existingproduct);
                        }
                    }
                }

            }
            var DiscountAmount = dto.DiscountAmount;
            var promoCode = await _repos.GetPromoCodeByName(dto.PromoCodeName);
            if (promoCode != null)
            {
                if (promoCode.DateTimeActive >= DateTime.Now)
                {
                    DiscountAmount += promoCode.DiscountAmount;
                }
            }
            var totalPrice = ((netPrice - DiscountAmount) * (1 + 0.16f)) + dto.DelievryPrice;
            var newOrder = new Order
            {
                Title = dto.Title,
                Note = dto.Note,
                Address = dto.Address,
                PaymentMethod = dto.PaymentMethod,
                DeliveryCity = dto.DeliveryCity,
                DelievryPrice = dto.DelievryPrice,
                Status = OrderStatus.Processing,
                PromoCode = promoCode,
                OrderDate = dto.OrderDate,
                DiscountAmount = DiscountAmount,
                TaxAmount = 0.16f,
                NetPrice = netPrice,
                TotalPrice = totalPrice,
                Cart = cart
            };
            var existingcart = new Cart
            {
                Id = dto.CartId,
                Status = CartStatus.Completed
            };
            await _repos.CompletedCart(existingcart);
            await _repos.CreateOrder(newOrder);
        }
        #endregion

        #region Order Mangement
        public async Task<int> CreateOrder(CreateOrUpdateOrderDTO dto)
        {
            var netPrice = 0f;
            var listCartItem = new List<CartItem>();
            foreach (var n in dto.Items)
            {
                var package = await _repos.GetPackageById(n.ItemId);
                var product = await _repos.GetProductById(n.ItemId);
                if (package != null)
                {
                    if (package.Quantity < n.ItemQuantity)
                    {
                        throw new ArgumentException("out of stock");
                    }
                    else
                    {
                        package.Quantity -= n.ItemQuantity;
                        netPrice += (n.ItemQuantity * package.Price);
                        var existingpackage = new Package
                        {
                            Id = n.ItemId,
                            Quantity = package.Quantity
                        };
                        await _repos.UpdatePackage(existingpackage);
                    }
                }
                else if (product != null)
                {
                    if (product.Quantity < n.ItemQuantity)
                    {
                        throw new ArgumentException("out of stock");
                    }
                    else
                    {
                        product.Quantity -= n.ItemQuantity;
                        netPrice += (n.ItemQuantity * product.Price);
                        var existingproduct = new Product
                        {
                            Id = n.ItemId,
                            Quantity = product.Quantity
                        };
                        await _repos.UpdateProduct(existingproduct);
                    }
                }
                var cartItem = new CartItem
                {
                    Note = n.ItemNote,
                    Quantity = n.ItemQuantity,
                    Package = package,
                    Product = product
                };

                listCartItem.Add(cartItem);
            }
            var cart = new Cart();
            cart.CartItems = listCartItem;
            cart.Status = CartStatus.Processing;
            var DiscountAmount = dto.DiscountAmount;
            var promoCode = await _repos.GetPromoCodeByName(dto.PromoCodeName);
            if (promoCode != null)
            {
                if (promoCode.DateTimeActive >= DateTime.Now)
                {
                    DiscountAmount += promoCode.DiscountAmount;
                }
            }
            var totalPrice = ((netPrice - DiscountAmount) * (1 + 0.16f)) + dto.DelievryPrice;
            var order = new Order
            {
                Title = dto.Title,
                Note = dto.Note,
                Address = dto.Address,
                PaymentMethod = dto.PaymentMethod,
                DeliveryCity = dto.DeliveryCity,
                DelievryPrice = dto.DelievryPrice,
                Status = OrderStatus.Processing,
                PromoCode = promoCode,
                OrderDate = dto.OrderDate,
                DiscountAmount = DiscountAmount,
                TaxAmount = 0.16f,
                NetPrice = netPrice,
                TotalPrice = totalPrice,
                Cart = cart,
            };
            return await _repos.CreateOrder(order);
        }
        public async Task CreateOrderUser(OrderClientDTO dto)
        {
            var orderUser = new OrderUser
            {
                User = await _repos.GetClientById(dto.ClientId),
            };
          //  return await _repos.CreateOrderUser(orderUser);
        }
        public async Task<PrintInvoiceDTO> PrintInvoice(int orderId)
        {
            return await _repos.PrintInvoice(orderId);
        }
        #endregion

        #region Review Mangement
        public Task<List<ReviewRecordDTO>> GetReview(int ClientId)
        {
            return _repos.GetReview(ClientId);
        }
        public Task CreateReview(CreateOrUpdateReviewDTO dto)
        {
            return _repos.CreateReview(dto);
        }


        #endregion

    }
}
