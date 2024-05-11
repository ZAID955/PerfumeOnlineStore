using Microsoft.EntityFrameworkCore;
using PerfumeOnlineStore_Core.Dtos.Admin.PromoCode;
using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Client.Invoice;
using PerfumeOnlineStore_Core.Dtos.Client.Review;
using PerfumeOnlineStore_Core.IRepos;
using PerfumeOnlineStore_Core.Models.Context;
using PerfumeOnlineStore_Core.Models.Entites;
using System.Net;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;
namespace PerfumeOnlineStore_Infra.ReposImplementation
{
    public class ClientRepos : IClientReposInterface
    {
        private readonly PerfumeOnlineStoreDbContext _context;
        public ClientRepos(PerfumeOnlineStoreDbContext context)
        {
            _context = context;
        }
        #region Account Management
        public async Task<int> CreateAccountToclient(RegistrationClientDTO dto)
        {

            var result = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email
                                                                        || x.PhoneNumber == dto.PhoneNumber
                                                                        && x.UserType == UserType.Client);
            if (result != null)
            {
                if (result.PhoneNumber != null && result.Email != null)
                {
                    throw new ArgumentException("The Client PhoneNumber is already in use.");
                    throw new ArgumentException("The Client Email is already in use.");
                }
                else if (result.PhoneNumber != null && result.Email == null)
                {
                    throw new ArgumentException("The Client PhoneNumber is already in use.");
                }
                else if (result.PhoneNumber == null && result.Email != null)
                {
                    throw new ArgumentException("The Client Email is already in use.");
                }
                return 0;
            }
            else
            {
                var newClient = new User
                {
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    Password = dto.Password,
                    ConfirmPassword = dto.ConfirmPassword,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    SecondName = dto.SecondName,
                    Name = dto.Name,
                    Brithday = dto.Brithday,
                    Gendear = dto.Gendear
                };
                newClient.UserType = UserType.Client;
                await _context.Users.AddAsync(newClient);
                await _context.SaveChangesAsync();
                return newClient.Id;
            }
        }
        public async Task<int> Login(LoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email
                                                                && u.Password == dto.Password);
            if (user == null)
            {
                throw new KeyNotFoundException("UserName or Password Incorrect ");
            }
            return user.Id;
        }
        public async Task<int> UpdateProfile(UpdateProfileClientDTO dto)
        {
            var client = await _context.Users.FindAsync(dto.Id);

            if (client != null)
            {
                if (client.PhoneNumber == dto.PhoneNumber && client.Email == dto.Email)
                {
                    throw new ArgumentException("The Client PhoneNumber is already in use.");
                    throw new ArgumentException("The Client Email is already in use.");
                }
                else if (client.PhoneNumber == dto.PhoneNumber && client.Email != dto.Email)
                {
                    throw new ArgumentException("The Client PhoneNumber is already in use.");
                }
                else if (client.PhoneNumber != dto.PhoneNumber && client.Email == dto.Email)
                {
                    throw new ArgumentException("The Client Email is already in use.");
                }
                else
                {
                    client.PhoneNumber = dto.PhoneNumber;
                    client.Email = dto.Email;
                    client.FirstName = dto.FirstName;
                    client.LastName = dto.LastName;
                    client.SecondName = dto.SecondName;
                    client.Brithday = dto.Brithday;
                    client.Gendear = dto.Gendear;

                    return await _context.SaveChangesAsync();
                }
            }
            else
            {
                throw new ArgumentException("Client not found");
            }
        }
        public async Task<User> GetClientById(int ClientId)
        {
            var result = new User();
            var selectUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == ClientId
                                                                        && x.UserType == UserType.Client);
            result.Id = ClientId;
            result.IsActive = selectUser.IsActive;
            result.CreationDateTime = selectUser.CreationDateTime;
            result.Email = selectUser.Email;
            result.FirstName = selectUser.FirstName;
            result.LastName = selectUser.LastName;
            result.SecondName = selectUser.SecondName;
            result.PhoneNumber = selectUser.PhoneNumber;
            result.ConfirmPassword = selectUser.ConfirmPassword;
            result.Brithday = selectUser.Brithday;
            result.Gendear = selectUser.Gendear;
            result.UserType = selectUser.UserType;

            return result;
        }
        #endregion

        #region
        public async Task<int> CreateCart(Cart cart)
        {
             _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart.Id;
        }
        public async Task<int> CreateCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return cartItem.Id;
        }
        public async Task<int> SavedCartForLater(Cart cart)
        {
            var existingCart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == cart.Id
                                                                        && x.Status == CartStatus.Processing);
            if (existingCart == null)
            {
                throw new ArgumentException("Cart not found.");
            }
            else
            {
                existingCart.Status = CartStatus.SavedForLater;

                await _context.SaveChangesAsync();
                return existingCart.Id;
            }
        }
        public async Task<int> CancelledCart(Cart cart)
        {
            var existingCart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == cart.Id
                                                                        && x.Status == CartStatus.Processing
                                                                        || x.Status == CartStatus.SavedForLater);
            if (existingCart == null)
            {
                throw new ArgumentException("Cart not found.");
            }
            else
            {
                existingCart.Status = CartStatus.Cancelled;

                await _context.SaveChangesAsync();
                return existingCart.Id;
            }
        }
        public async Task<int> CompletShopping(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }
        public async Task CompletedCart(Cart cart)
        {
            var existingcart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == cart.Id
                                                            && x.Status == CartStatus.Processing
                                                            || x.Status == CartStatus.SavedForLater);
            if (existingcart == null)
            {
                throw new ArgumentException("Cart not found.");
            }
            else
            {
                existingcart.Status = CartStatus.Completed;

                await _context.SaveChangesAsync();
            }
        }
        public async Task<Cart> GetCartById(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return null;
            }
            else
            {
                return cart;
            }
        }
        #endregion

        public async Task<Product> GetProductById(int id)
        {
            var products = await _context.Productes.FindAsync(id);
            if (products == null)
            {
                return null;
            }
            else
            {
                return products;
            }
        }
        public async Task<Package> GetPackageById(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return null;
            }
            else
            {
                return package;
            }
        }
        public async Task UpdateProduct(Product product)
        {
            var existingProduct = await _context.Productes.FindAsync(product.Id);
            if (existingProduct == null)
            {
                throw new ArgumentException("Product not found.");
            }
            else
            {
                existingProduct.Quantity = product.Quantity;

                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdatePackage(Package package)
        {
            var existingPackage = await _context.Packages.FindAsync(package.Id);
            if (existingPackage == null)
            {
                throw new ArgumentException("Package not found.");
            }
            else
            {
                existingPackage.Quantity = package.Quantity;

                await _context.SaveChangesAsync();
            }
        }
        public async Task<PromoCode> GetPromoCodeByName(string? PromoCodeName)
        {
            if (PromoCodeName == null)
            {
                return null;
            }
            else
            {
                var promoCode = await _context.PromoCodes.FirstOrDefaultAsync(x => x.Name == PromoCodeName);
                if (promoCode == null)
                {
                    return null;

                }
                else
                {
                    return promoCode;
                }
            }
        }
        public async Task<int> CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;

        }
        public async Task<List<InvoiceItemsDetailsDTO>> GetInvoiceItemsInCart(int orderId)
        {
            var invoiceItems = new List<InvoiceItemsDetailsDTO>();
            var result = await _context.Orders
                .Include(c => c.Cart)
                    .ThenInclude(ci => ci.CartItems)
                        .ThenInclude(pa => pa.Package)
                .Include(c => c.Cart)
                    .ThenInclude(ci => ci.CartItems)
                        .ThenInclude(pr => pr.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
            if (result == null)
            {
                return null;
            }
            else
            {
                foreach (var carItem in result.Cart.CartItems)
                {
                    var ItemsDetails = new InvoiceItemsDetailsDTO();
                    if (carItem.Product != null)
                    {
                        ItemsDetails.ItemPricePerUnit = carItem.Product.Price;
                        ItemsDetails.ItemQuantity = carItem.Quantity;
                        ItemsDetails.ItemName = carItem.Product.Name;
                        ItemsDetails.ItemNote = carItem.Note;
                    }
                    else if (carItem.Package != null)
                    {
                        ItemsDetails.ItemPricePerUnit = carItem.Package.Price;
                        ItemsDetails.ItemQuantity = carItem.Quantity;
                        ItemsDetails.ItemName = carItem.Package.Name;
                        ItemsDetails.ItemNote = carItem.Note;
                    }
                    else
                    {
                        return null;
                    }
                    invoiceItems.Add(ItemsDetails);
                }
            }
            return invoiceItems.ToList();
        }
        public async Task<PrintInvoiceDTO> PrintInvoice(int orderId)
        {
            var Invoice = new PrintInvoiceDTO();
            var result = await _context.Orders
                                    .Include(c => c.Cart)
                                        .ThenInclude(ci => ci.CartItems)
                                            .ThenInclude(pa => pa.Package)
                                    .Include(c => c.Cart)
                                        .ThenInclude(ci => ci.CartItems)
                                            .ThenInclude(pr => pr.Product)
                                    .FirstOrDefaultAsync(o => o.Id == orderId);
            if (result != null)
            {
                var firstletter = result.DeliveryCity.ToString().Substring(0, 3);
                Invoice.InvoiceTitle = $"{firstletter}-{result.Id} {DateTime.Now}";
                Invoice.DelievryPrice = result.DelievryPrice;
                Invoice.NetPrice = result.NetPrice;
                Invoice.TotalPrice = result.TotalPrice;
                Invoice.DiscountAmount = result.DiscountAmount;
                Invoice.TaxAmount = result.TaxAmount;
                Invoice.PaymentMethod = result.PaymentMethod.ToString();
                Invoice.OrderId = orderId;
                Invoice.Address = result.Address;
                Invoice.ItemsDetails = new List<InvoiceItemsDetailsDTO>();
                foreach (var carItem in result.Cart.CartItems)
                {
                    var ItemsDetails = new InvoiceItemsDetailsDTO();
                    if (carItem.Product != null)
                    {
                        ItemsDetails.ItemPricePerUnit = carItem.Product.Price;
                        ItemsDetails.ItemQuantity = carItem.Quantity;
                        ItemsDetails.ItemName = carItem.Product.Name;
                        ItemsDetails.ItemNote = carItem.Note;
                    }
                    else if (carItem.Package != null)
                    {
                        ItemsDetails.ItemPricePerUnit = carItem.Package.Price;
                        ItemsDetails.ItemQuantity = carItem.Quantity;
                        ItemsDetails.ItemName = carItem.Package.Name;
                        ItemsDetails.ItemNote = carItem.Note;
                    }
                    else
                    {
                        return null;
                    }
                    ItemsDetails.Price = ItemsDetails.ItemQuantity * ItemsDetails.ItemPricePerUnit;
                    Invoice.ItemsDetails.Add(ItemsDetails);
                    Invoice.ItemsDetails.ToList();
                }
                return Invoice;
            }
            else
            {
                return null;
            }

        }
        public async Task UpdateOrder(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);
            if (existingOrder == null)
            {
                throw new ArgumentException("order not found.");
            }
            else
            {
                existingOrder.Status = order.Status;

                await _context.SaveChangesAsync();
            }

        }

        #region Review Mangement
        public async Task CreateReview(CreateOrUpdateReviewDTO dto)
        {
            var newReview = new Review
            {
                Title = dto.Title,
                Rating = dto.Rating,
                Comment = dto.Comment,
                User = await GetClientById(dto.clientId),
                Product = await GetProductById(dto.ItemId),
                Package = await GetPackageById(dto.ItemId)
            };
            await _context.Reviews.AddAsync(newReview);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ReviewRecordDTO>> GetReview(int clientId)
        {
            var reviews = await _context.Reviews
            .Where(r => r.User.Id == clientId)
            .Include(r => r.Product)
            .Include(r => r.Package)
            .Select(r => new ReviewRecordDTO
            {
                Id = r.Id,
                ReviewTitle = r.Title,
                ItemName = r.Product != null ? r.Product.Name : r.Package.Name,
                ItemId = r.Product != null ? r.Product.Id : r.Package.Id,
                Rating = r.Rating,
                DateTimeCreated = r.CreationDateTime
            }).ToListAsync();

            return reviews;
        }
        #endregion
    }
}
