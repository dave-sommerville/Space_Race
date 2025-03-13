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

            // Many-to-many relationship between Tournament and Driver
            modelBuilder.Entity<Tournament>()
                .HasMany(t => t.Drivers)
                .WithMany(d => d.Tournaments)
                .UsingEntity<Dictionary<string, object>>(
                    "TournamentDriver",
                    j => j.HasOne<Driver>().WithMany().HasForeignKey("DriverId"),
                    j => j.HasOne<Tournament>().WithMany().HasForeignKey("TournamentId"),
                    j => j.HasKey("DriverId", "TournamentId")
                );
            modelBuilder.Entity<Tournament>()
                .HasOne(t => t.TourFirstPlace)
                .WithMany()
                .HasForeignKey(t => t.TourFirstPlaceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tournament>()
                .HasOne(t => t.TourSecondPlace)
                .WithMany()
                .HasForeignKey(t => t.TourSecondPlaceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tournament>()
                .HasOne(t => t.TourThirdPlace)
                .WithMany()
                .HasForeignKey(t => t.TourThirdPlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-one relationship between Driver and Vehicle
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Vehicle)
                .WithOne(v => v.Driver)
                .HasForeignKey<Driver>(d => d.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);



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
