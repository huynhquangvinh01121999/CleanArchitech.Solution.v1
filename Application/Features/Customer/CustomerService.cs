using Application.DTOs;
using Application.Mappings;
using Application.Wrappers;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepositoryAsync _customerRepositoryAsync;

        public CustomerService(ICustomerRepositoryAsync customerRepositoryAsync)
        {
            _customerRepositoryAsync = customerRepositoryAsync;
        }

        public Task<Customers> CreateCustomer(Customers entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customers> GetById()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<IEnumerable<CustomerDto>>> GetCustomers(int pageNumber, int pageSize)
        {
            var customers = await _customerRepositoryAsync.GetCustomers(pageNumber, pageSize);
            var totalItems = await _customerRepositoryAsync.GetTotalItem();
            return new PagedResponse<IEnumerable<CustomerDto>>(customers.MappingCustomeDtos(), pageNumber, pageSize, totalItems);
        }
    }
}
