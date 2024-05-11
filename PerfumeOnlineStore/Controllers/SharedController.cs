using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeOnlineStore_Core.IServices;
using PerfumeOnlineStore_Infra.ServiceImplementation;

namespace PerfumeOnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly ISharedServiceInterface _sharedService;
        public SharedController(ISharedServiceInterface sharedService)
        {
            _sharedService = sharedService;
        }
        /*
        #region #region Account Management
        [HttpPut]
        [Route("[action]")]
        public async  Task<IActionResult> ResetPassword(UpdatePasswordDTO dto)
        {
            try
            {
                var result =  _employeeService.ResetPassword(dto);
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
        */
    }
}
