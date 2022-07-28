using Meter_Project.Models;
using Meter_Project.Models.MeterContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meter_Project.Repository_Layer
{
    public class MeterRepository : IMeterRepository
    {
        private readonly MeterDbContext _meterDbContext;
        public MeterRepository(MeterDbContext meterDbContext)
        {
            _meterDbContext = meterDbContext;
        }

        public object FindDetailsAtCityLevel(string dateRange)
        {
            var meter = (from c in _meterDbContext.Cities
                         join f in _meterDbContext.Facilities 
                         on c.CityId equals f.City.CityId into res1
                         from f in res1.DefaultIfEmpty()
                         join b in _meterDbContext.Buildings
                         on f.FacilityId equals b.Facility.FacilityId into res2
                         from b in res2.DefaultIfEmpty()
                         join fl in _meterDbContext.Floors
                         on b.BuildingId equals fl.Building.BuildingId into res3
                         from fl in res3.DefaultIfEmpty()
                         join z in _meterDbContext.Zones
                         on fl.FloorId equals z.Floor.FloorId into res4
                         from z in res4.DefaultIfEmpty()
                         join m in _meterDbContext.Meters
                         on z.ZoneId equals m.Zone.ZoneId into res5
                         from m in res5.DefaultIfEmpty()
                         where m.InstalledAt >= DateTime.Parse(dateRange)
                         select new
                         {
                             CityId = c.CityId,
                             CityName = c.CityName,
                             FacilityName = f.FacilityName,
                             BuildingName = b.BuildingName,
                             FloorName = fl.FloorName,
                             ZoneName = z.ZoneName,
                             MeterInfo = m

                         }).ToList();

            return meter;
        }

        public object FindDetailsAtFacilityLevel(string dateRange)
        {
            var meter = (
                         from f in _meterDbContext.Facilities
                         join b in _meterDbContext.Buildings
                         on f.FacilityId equals b.Facility.FacilityId into res2
                         from b in res2.DefaultIfEmpty()
                         join fl in _meterDbContext.Floors
                         on b.BuildingId equals fl.Building.BuildingId into res3
                         from fl in res3.DefaultIfEmpty()
                         join z in _meterDbContext.Zones
                         on fl.FloorId equals z.Floor.FloorId into res4
                         from z in res4.DefaultIfEmpty()
                         join m in _meterDbContext.Meters
                         on z.ZoneId equals m.Zone.ZoneId into res5
                         from m in res5.DefaultIfEmpty()
                         where m.InstalledAt >= DateTime.Parse(dateRange)
                         select new
                         {
                             FacilityId = f.FacilityId,
                             FacilityName = f.FacilityName,
                             BuildingName = b.BuildingName,
                             FloorName = fl.FloorName,
                             ZoneName = z.ZoneName,
                             MeterInfo = m

                         }).ToList();

            return meter;
        }

        public object FindDetailsAtBuildingLevel(string dateRange)
        {
            var meter = (from b in _meterDbContext.Buildings
                         join fl in _meterDbContext.Floors
                         on b.BuildingId equals fl.Building.BuildingId into res3
                         from fl in res3.DefaultIfEmpty()
                         join z in _meterDbContext.Zones
                         on fl.FloorId equals z.Floor.FloorId into res4
                         from z in res4.DefaultIfEmpty()
                         join m in _meterDbContext.Meters
                         on z.ZoneId equals m.Zone.ZoneId into res5
                         from m in res5.DefaultIfEmpty()
                         where m.InstalledAt >= DateTime.Parse(dateRange)
                         select new
                         {
                             BuildingId = b.BuildingId,
                             BuildingName = b.BuildingName,
                             FloorName = fl.FloorName,
                             ZoneName = z.ZoneName,
                             MeterInfo = m

                         }).ToList();

            return meter;
        }
        public object FindDetailsAtFloorLevel(string dateRange)
        {
            var meter = (from fl in _meterDbContext.Floors
                         join z in _meterDbContext.Zones
                         on fl.FloorId equals z.Floor.FloorId into res4
                         from z in res4.DefaultIfEmpty()
                         join m in _meterDbContext.Meters
                         on z.ZoneId equals m.Zone.ZoneId into res5
                         from m in res5.DefaultIfEmpty()
                         where m.InstalledAt >= DateTime.Parse(dateRange)
                         select new
                         {
                             FloorId = fl.FloorId,
                             FloorName = fl.FloorName,
                             ZoneName = z.ZoneName,
                             MeterInfo = m

                         }).ToList();

            return meter;
        }

        public object FindDetailsAtZoneLevel(string dateRange)
        {
            var meter = (from z in _meterDbContext.Zones
                         join m in _meterDbContext.Meters
                         on z.ZoneId equals m.Zone.ZoneId into res5
                         from m in res5.DefaultIfEmpty()
                         where m.InstalledAt >= DateTime.Parse(dateRange)
                         select new
                         {
                             ZoneId = z.ZoneId, 
                             ZoneName = z.ZoneName,
                             MeterInfo = m

                         }).ToList();

            return meter;
        }

        public object FindDetailsAtMeterLevel(string dateRange)
        {
            return _meterDbContext.Meters.Where(m => m.InstalledAt >= DateTime.Parse(dateRange));
        }











    }
}
