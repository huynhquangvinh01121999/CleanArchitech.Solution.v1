using Domain.Entities;
using Domain.IRepositories;
using Infrastructure;

namespace Persistence.Repositories
{
    public class PersonRepositoryAsync : BaseRepositoryAsync<Person>, IPersonRepositoryAsync
    {
        public PersonRepositoryAsync(ApplicationDbContext context) : base(context)
        {
        }
    }
}
