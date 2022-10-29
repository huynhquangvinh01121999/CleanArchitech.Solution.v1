using Application.StoredProcedures;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CustomerRepositoryAsync : BaseRepositoryAsync<Customers>, ICustomerRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IList<Customers>> GetCustomers(int pageNumber, int pageSize)
        {
            var parameter = new[]
            {
                new SqlParameter("@pageNumber",SqlDbType.Int) {Direction = ParameterDirection.Input, Value = pageNumber},
                new SqlParameter("@pageSize",SqlDbType.Int) {Direction = ParameterDirection.Input, Value = pageSize}
            };

            string sql = string.Format("[{0}] @pageNumber, @pageSize", Procedures.GetCustomers);

            var customers = await _dbContext.Set<Customers>()
                                            .FromSqlRaw(sql.ToString(), parameter)
                                            .ToListAsync();

            return customers;
        }
    }
}
