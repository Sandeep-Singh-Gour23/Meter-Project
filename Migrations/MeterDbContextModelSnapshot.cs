// <auto-generated />
using System;
using Meter_Project.Models.MeterContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meter_Project.Migrations
{
    [DbContext(typeof(MeterDbContext))]
    partial class MeterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Meter_Project.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuildingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacilityId")
                        .HasColumnType("int");

                    b.HasKey("BuildingId");

                    b.HasIndex("FacilityId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Meter_Project.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Meter_Project.Models.Facility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FacilityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacilityId");

                    b.HasIndex("CityId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("Meter_Project.Models.Floor", b =>
                {
                    b.Property<int>("FloorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuildingId")
                        .HasColumnType("int");

                    b.Property<string>("FloorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FloorId");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("Meter_Project.Models.Meter", b =>
                {
                    b.Property<int>("MeterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CurrentReading")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("InstalledAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MeterType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("MeterId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Meters");
                });

            modelBuilder.Entity("Meter_Project.Models.Zone", b =>
                {
                    b.Property<int>("ZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FloorId")
                        .HasColumnType("int");

                    b.Property<string>("ZoneName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZoneId");

                    b.HasIndex("FloorId");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("Meter_Project.Models.Building", b =>
                {
                    b.HasOne("Meter_Project.Models.Facility", "Facility")
                        .WithMany("buildings")
                        .HasForeignKey("FacilityId");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("Meter_Project.Models.Facility", b =>
                {
                    b.HasOne("Meter_Project.Models.City", "City")
                        .WithMany("facilities")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Meter_Project.Models.Floor", b =>
                {
                    b.HasOne("Meter_Project.Models.Building", "Building")
                        .WithMany("floors")
                        .HasForeignKey("BuildingId");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Meter_Project.Models.Meter", b =>
                {
                    b.HasOne("Meter_Project.Models.Zone", "Zone")
                        .WithMany("meters")
                        .HasForeignKey("ZoneId");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("Meter_Project.Models.Zone", b =>
                {
                    b.HasOne("Meter_Project.Models.Floor", "Floor")
                        .WithMany("zones")
                        .HasForeignKey("FloorId");

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("Meter_Project.Models.Building", b =>
                {
                    b.Navigation("floors");
                });

            modelBuilder.Entity("Meter_Project.Models.City", b =>
                {
                    b.Navigation("facilities");
                });

            modelBuilder.Entity("Meter_Project.Models.Facility", b =>
                {
                    b.Navigation("buildings");
                });

            modelBuilder.Entity("Meter_Project.Models.Floor", b =>
                {
                    b.Navigation("zones");
                });

            modelBuilder.Entity("Meter_Project.Models.Zone", b =>
                {
                    b.Navigation("meters");
                });
#pragma warning restore 612, 618
        }
    }
}
