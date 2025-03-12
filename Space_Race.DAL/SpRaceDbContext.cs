using Microsoft.EntityFrameworkCore;
using Space_Race.Models;

namespace Space_Race.DAL
{
    public class SpRaceDbContext : DbContext
    {
        public SpRaceDbContext(DbContextOptions<SpRaceDbContext> options) : base(options)
        {
        }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<Tournament>()
                .HasKey(t => t.TournamentId);
            modelBuilder.Entity<Driver>()
                .HasKey(d => d.DriverId);
            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.VehicleId);

            // One-to-many relationship between Tournament and Driver
            modelBuilder.Entity<Tournament>()
                .HasMany<Driver>(t => t.Drivers)
                .WithOne()
                .HasForeignKey(d => d.TournamentId);
            // One-to-one relationship between Driver and Vehicle and visa versa
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Vehicle)
                .WithOne(v => v.Driver)
                .HasForeignKey<Driver>(d => d.VehicleId);
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Driver)
                .WithOne(d => d.Vehicle)
                .HasForeignKey<Vehicle>(v => v.DriverId);

            // Property constraints
            modelBuilder.Entity<Tournament>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Driver>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
