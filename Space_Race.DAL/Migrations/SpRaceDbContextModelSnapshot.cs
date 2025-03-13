﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Space_Race.DAL;

#nullable disable

namespace Space_Race.DAL.Migrations
{
    [DbContext(typeof(SpRaceDbContext))]
    partial class SpRaceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Space_Race.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriverId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("DriverId");

                    b.HasIndex("VehicleId")
                        .IsUnique()
                        .HasFilter("[VehicleId] IS NOT NULL");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Space_Race.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TournamentId"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TourFirstPlaceId")
                        .HasColumnType("int");

                    b.Property<int?>("TourSecondPlaceId")
                        .HasColumnType("int");

                    b.Property<int?>("TourThirdPlaceId")
                        .HasColumnType("int");

                    b.HasKey("TournamentId");

                    b.HasIndex("TourFirstPlaceId");

                    b.HasIndex("TourSecondPlaceId");

                    b.HasIndex("TourThirdPlaceId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Space_Race.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("TournamentDriver", b =>
                {
                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("DriverId", "TournamentId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentDriver");
                });

            modelBuilder.Entity("Space_Race.Models.Driver", b =>
                {
                    b.HasOne("Space_Race.Models.Vehicle", "Vehicle")
                        .WithOne("Driver")
                        .HasForeignKey("Space_Race.Models.Driver", "VehicleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Space_Race.Models.Tournament", b =>
                {
                    b.HasOne("Space_Race.Models.Driver", "TourFirstPlace")
                        .WithMany()
                        .HasForeignKey("TourFirstPlaceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Space_Race.Models.Driver", "TourSecondPlace")
                        .WithMany()
                        .HasForeignKey("TourSecondPlaceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Space_Race.Models.Driver", "TourThirdPlace")
                        .WithMany()
                        .HasForeignKey("TourThirdPlaceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("TourFirstPlace");

                    b.Navigation("TourSecondPlace");

                    b.Navigation("TourThirdPlace");
                });

            modelBuilder.Entity("TournamentDriver", b =>
                {
                    b.HasOne("Space_Race.Models.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Space_Race.Models.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Space_Race.Models.Vehicle", b =>
                {
                    b.Navigation("Driver");
                });
#pragma warning restore 612, 618
        }
    }
}
