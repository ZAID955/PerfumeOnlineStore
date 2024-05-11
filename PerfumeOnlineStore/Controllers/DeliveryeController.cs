using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeOnlineStore_Core.Dtos.Client.Account;
using PerfumeOnlineStore_Core.Dtos.Delivery;
using PerfumeOnlineStore_Core.Dtos.Supplier;
using PerfumeOnlineStore_Core.IServices;
using PerfumeOnlineStore_Infra.ServiceImplementation;

namespace PerfumeOnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryeController : ControllerBase
    {
        private readonly IDeliveryServiceInterface _deliveryService;
        public DeliveryeController(IDeliveryServiceInterface deliveryService)
        {
            _deliveryService = deliveryService;
        }

        #region Account Management 
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateAccountToDelivery(RegistrationDeliveryDTO dto)
        {

            var result = _deliveryService.CreateAccountToDelivery(dto);
            return Ok(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDeliveryDTO dto)
        {
            try
            {
                await _deliveryService.UpdateProfile(dto);
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

    }
}
