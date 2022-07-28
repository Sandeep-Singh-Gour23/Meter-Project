using Microsoft.EntityFrameworkCore;

namespace Meter_Project.Models.MeterContext
{
    public class MeterDbContext : DbContext
    {
        public MeterDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { 
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Meter> Meters { get; set; }

    }
}
