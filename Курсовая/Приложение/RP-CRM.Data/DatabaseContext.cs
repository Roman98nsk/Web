using Microsoft.EntityFrameworkCore;

namespace RP_CRM.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}