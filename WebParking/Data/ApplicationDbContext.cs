using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebParking.Domain.Models;

namespace WebParking.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<Client>()
                .HasIndex(b => b.Document)
                .IsUnique();

            builder.Entity<ClientCategory>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<Auto>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<AutoCategory>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<Tariff>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<ParkingPlace>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientCategory> ClientCategories { get; set; }

        public DbSet<Auto> Auto { get; set; }

        public DbSet<AutoCategory> AutoCategories { get; set; }

        public DbSet<Tariff> Tariffies { get; set; }

        public DbSet<ParkingPlace> ParkingPlace { get; set; }

    }
}