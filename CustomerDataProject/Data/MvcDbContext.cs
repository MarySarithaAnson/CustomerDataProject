using CustomerDataProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerDataProject.Data
{
    public class MvcDbContext : DbContext
    {
        public MvcDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CustomerInfo> CustomerDetails { get; set; }
    }
}
