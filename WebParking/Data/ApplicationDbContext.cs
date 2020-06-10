using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebParking.Domain.Models;

namespace WebParking.Data
{
    public class ApplicationDbContext : IdentityDbContext<WebParkingUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>(x =>
            {
                x.HasIndex(b => b.Document)
                .IsUnique();

                x.Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            builder.Entity<ClientCategory>(x =>
            {
                x.Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                x.HasIndex(b => b.Name)
                .IsUnique();
            });

            builder.Entity<Car>(x =>
            {
                x.Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                x.HasIndex(b => b.StateNumber)
                .IsUnique();
            });

            builder.Entity<CarCategory>(x =>
            {
                x.Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                x.HasIndex(b => b.Name)
                .IsUnique();

            });

            builder.Entity<Tariff>(x =>
            {
                x.Property(x => x.Creation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            });

            builder.Entity<ParkingPlace>(x =>
            {
                x.Property(x => x.Creation)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            builder.Entity<CheckInOut>(x =>
            {
                x.Property(x => x.Creation)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientCategory> ClientCategories { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarCategory> CarCategories { get; set; }

        public DbSet<Tariff> Tariffies { get; set; }

        public DbSet<ParkingPlace> ParkingPlaces { get; set; }

        public DbSet<CheckInOut> CheckInOuts { get; set; }

    }
}