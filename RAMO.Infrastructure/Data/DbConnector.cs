using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace RAMO.Infrastructure.Data
{
    public class DbConnector
    {
        private readonly IConfiguration _configuration;

        protected DbConnector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            //return new SqlConnection(
            //    _configuration.GetConnectionString("DefaultConnection"));
            string _connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(_connectionString);
        }
    }
}
