using Microsoft.EntityFrameworkCore;
using MyManagerShared.Models;

namespace MyManagerServices.Data
{
    public class MMServicesContext : DbContext
    {
        public MMServicesContext (DbContextOptions<MMServicesContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        // Build the tables in the sql server database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
        }
    }
}
