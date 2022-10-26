using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers
{
    public class CustomerService : ICustomerService
    {
        public Task<Domain.Entities.Customers> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Domain.Entities.Customers>> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
