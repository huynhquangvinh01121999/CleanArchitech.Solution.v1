using Application.DTOs;
using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Customer
{
    public interface ICustomerService
    {
        Task<Customers> GetById();
        Task<PagedResponse<IEnumerable<CustomerDto>>> GetCustomers(int pageNumber, int pageSize
                                                                    , string colFil, string keyword
                                                                    , DateTime? startDob, DateTime? endDob);
        Task<Customers> CreateCustomer(Customers entity);
    }
}
