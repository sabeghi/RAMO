using Microsoft.EntityFrameworkCore;
using RAMO.Core.Entities;

namespace RAMO.Infrastructure.Data
{
    public class RAMOContext : DbContext
    {
        public RAMOContext(DbContextOptions<RAMOContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
