using Application.DTOs;
using Application.Features.Customer;
using Application.Parameters.CustomerParams;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMemoryCache _memoryCache;

        public CustomerController(ICustomerService customerService, IMemoryCache memoryCache)
        {
            _customerService = customerService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCustomerParameters param)
        {
            var cacheKey = "customers";
            //checks if cache entries exists
            if (!_memoryCache.TryGetValue(cacheKey, out PagedResponse<IEnumerable<CustomerDto>> customers))
            {
                customers = await _customerService.GetCustomers(param.PageNumber, param.PageSize
                                                                , param.colFil, param.keyword
                                                                , param.startDob, param.endDob);
                //setting up cache options
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(10),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(5)
                };
                //setting cache entries
                _memoryCache.Set(cacheKey, customers, cacheExpiryOptions);
            }
            return Ok(customers);
        }
    }
}
