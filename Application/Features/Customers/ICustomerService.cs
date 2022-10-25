using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Customers
{
    public interface ICustomerService
    {
        Task<Domain.Entities.Customers> GetById();
        Task<IList<Domain.Entities.Customers>> GetCustomers();
    }
}
