using Domain.Entities;
using Domain.IRepositories;
using Infrastructure;

namespace Persistence.Repositories
{
    public class CustomerRepositoryAsync : BaseRepositoryAsync<Customers>, ICustomerRepositoryAsync
    {
        public CustomerRepositoryAsync(ApplicationDbContext context) : base(context)
        {
        }
    }
}
