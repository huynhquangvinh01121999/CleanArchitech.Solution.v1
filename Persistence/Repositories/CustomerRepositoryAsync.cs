using Application.StoredProcedures;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CustomerRepositoryAsync : BaseRepositoryAsync<Customers>, ICustomerRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private int _totalItem = 0;

        public CustomerRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<int> GetTotalItem()
        {
            return _totalItem;
        }

        public async Task<IList<Customers>> GetCustomers(int pageNumber, int pageSize)
        {
            var parameter = new[]
            {
                new SqlParameter("@pageNumber",SqlDbType.Int) {Direction = ParameterDirection.Input, Value = pageNumber},
                new SqlParameter("@pageSize",SqlDbType.Int) {Direction = ParameterDirection.Input, Value = pageSize},
                new SqlParameter("@totalItems",SqlDbType.Int) {Direction = ParameterDirection.InputOutput, Value = 0}
            };

            string sql = string.Format("[{0}] @pageNumber, @pageSize, @totalItems output", Procedures.GetCustomers);

            var customers = await _dbContext.Set<Customers>()
                                            .FromSqlRaw(sql.ToString(), parameter)
                                            .ToListAsync();

            _totalItem = Convert.ToInt32(parameter[2].Value);

            return customers;
        }
    }
}
