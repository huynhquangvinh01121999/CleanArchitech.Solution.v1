using Application.DTOs;
using Application.Wrappers;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Customer
{
    public interface ICustomerService
    {
        Task<Customers> GetById();
        Task<PagedResponse<IEnumerable<CustomerDto>>> GetCustomers(int pageNumber, int pageSize);
        Task<Customers> CreateCustomer(Customers entity);
    }
}
