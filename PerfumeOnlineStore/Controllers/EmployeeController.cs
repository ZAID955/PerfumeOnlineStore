using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeOnlineStore_Core.IServices;

namespace PerfumeOnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServiceInterface _employeeService;
        public EmployeeController(IEmployeeServiceInterface employeeService)
        {
            _employeeService = employeeService;
        }
    }
}
