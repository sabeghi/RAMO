using Dapper;
using Microsoft.Extensions.Configuration;
using RAMO.Core.Entities;
using RAMO.Core.Repositories.Query;
using RAMO.Infrastructure.Repositories.Query.Base;
using System.Data;

namespace RAMO.Infrastructure.Repositories.Query
{
    public class CustomerQueryRepository : QueryRepository<Customer>, ICustomerQueryRepository
    {
        public CustomerQueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM CUSTOMERS";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Customer>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Customer> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM CUSTOMERS WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Customer>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            try
            {
                var query = "SELECT * FROM CUSTOMERS WHERE Email = @email";
                var parameters = new DynamicParameters();
                parameters.Add("Email", email, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Customer>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
