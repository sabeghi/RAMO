using Microsoft.Extensions.Configuration;
using RAMO.Core.Repositories.Query.Base;
using RAMO.Infrastructure.Data;


namespace RAMO.Infrastructure.Repositories.Query.Base
{
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
