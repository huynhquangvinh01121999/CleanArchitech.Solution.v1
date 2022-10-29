using Application.Features.Customer;
using Application.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestParameter param)
        {
            return Ok(await _customerService.GetCustomers(param.PageNumber, param.PageSize));
        }
    }
}
