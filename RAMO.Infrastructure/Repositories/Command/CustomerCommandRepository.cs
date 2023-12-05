using RAMO.Core.Entities;
using RAMO.Core.Repositories.Command;
using RAMO.Infrastructure.Data;
using RAMO.Infrastructure.Repositories.Command.Base;

namespace RAMO.Infrastructure.Repositories.Command
{
    public class CustomerCommandRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(RAMOContext context) : base(context)
        {

        }
    }
}
