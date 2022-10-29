using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface ICustomerRepositoryAsync : IBaseRepositoryAsync<Customers>
    {
        Task<int> GetTotalItem();
        Task<IList<Customers>> GetCustomers(int pageNumber, int pageSize);
    }
}
