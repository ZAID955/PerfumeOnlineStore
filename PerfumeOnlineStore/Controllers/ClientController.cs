using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Client.Cart;
using PerfumeOnlineStore_Core.Dtos.Client.CartItem;
using PerfumeOnlineStore_Core.Dtos.Client.Order;
using PerfumeOnlineStore_Core.Dtos.Client.Review;
using PerfumeOnlineStore_Core.IServices;
using PerfumeOnlineStore_Infra.ServiceImplementation;

namespace PerfumeOnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServiceInterface _clientService;
        public ClientController(IClientServiceInterface clientService)
        {
            _clientService = clientService;
        }

        #region Account Management 
        [HttpPost]
        [Route("[action]")]
        public async  Task<IActionResult> CreateAccountToclient(RegistrationClientDTO dto)
        {
    
                var result =  _clientService.CreateAccountToclient(dto);
                return Ok(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileClientDTO dto)
        {
            try
            {
                await _clientService.UpdateProfile(dto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion


        #region
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCart(int ClientId)
        {
            try
            {
                await _clientService.CreateCart(ClientId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SelectCartItem(SelectItemDTO dto)
        {
            try
            {
                await _clientService.SelectCartItem(dto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> SavedCartForLater(int CartId)
        {
            try
            {
                await _clientService.SavedCartForLater(CartId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> CanceledCart(int CartId)
        {
            try
            {
                await _clientService.CanceledCart(CartId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CompletShopping(CompletShoppingDTO dto)
        {
            try
            {
                await _clientService.CompletShopping(dto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateOrder(CreateOrUpdateOrderDTO dto)
        {
            try
            {
                await _clientService.CreateOrder(dto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> PrintInvoice(int id)
        {
            try
            {
                var productSize = await _clientService.PrintInvoice(id);
                if (productSize == null)
                {
                    return NotFound();
                }
                return Ok(productSize);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #region Review Mangement
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetReview(int ClientId)
        {
            try
            {
                var result = _clientService.GetReview(ClientId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateReview(CreateOrUpdateReviewDTO dto)
        {
            try
            {
                var result = _clientService.CreateReview(dto);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion
    }
}
        /*
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDTO dto)
        {
            try
            {
                var result = _clientService.UpdateProfile(dto);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region Cart and CartItem Mangement
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddCartItemToCart(int cartId, int cartItemId)
        {
            try
            {
                var result = _clientService.AddCartItemToCart(cartId,  cartItemId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCartItem(CreateOrUpdateCartItemDTO dto)
        {
            try
            {
                var result = _clientService.CreateCartItem(dto);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            try
            {
                var result = _clientService.DeleteCart(cartId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> RemoveCartItemFromCart(int cartItemId)
        {
            try
            {
                var result = _clientService.RemoveCartItemFromCart(cartItemId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCart(int clientId)
        {
            try
            {
                var result = _clientService.CreateCart(clientId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCartItem(CreateOrUpdateCartItemDTO dto)
        {
            try
            {
                var result = _clientService.UpdateCartItem(dto);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region Order Mangement
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> OrderDetails(int orderId)
        {
            try
            {
                var result = _clientService.OrderDetails(orderId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion


        */
