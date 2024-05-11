using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeOnlineStore_Core.Dtos.Delivery;
using PerfumeOnlineStore_Core.Dtos.Supplier;
using PerfumeOnlineStore_Core.IServices;
using PerfumeOnlineStore_Infra.ServiceImplementation;

namespace PerfumeOnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierServiceInterface _supplierService;
        public SupplierController(ISupplierServiceInterface supplierService)
        {
            _supplierService = supplierService;
        }

        #region Account Management 
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateAccountToSupplier(RegistrationSupplierDTO dto)
        {

            var result = _supplierService.CreateAccountToSupplier(dto);
            return Ok(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileSupplierDTO dto)
        {
            try
            {
                await _supplierService.UpdateProfile(dto);
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
