using AmentumExploratory.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmentumExploratory.Data
{
    public class ExploratoryDbContext : DbContext
    {
        public ExploratoryDbContext()
        {

        }

        public ExploratoryDbContext(DbContextOptions<ExploratoryDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(s => s.ContactDateTime)
                .HasDefaultValueSql("GETDATE()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
