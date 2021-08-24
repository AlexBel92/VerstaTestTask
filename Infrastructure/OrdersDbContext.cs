using Microsoft.EntityFrameworkCore;
using VerstaTestTask.Core.Models;

namespace VerstaTestTask.Infrastructure
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public OrdersDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.RecipientCity).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(o => o.RecipientAddress).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(o => o.SenderCity).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(o => o.SenderAddress).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<City>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Address>().HasIndex(a => new { a.CityId, a.ZipCode, a.Street, a.House, a.Apartment }).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
