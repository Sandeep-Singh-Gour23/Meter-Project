using Meter_Project.Models;
using System.Collections.Generic;

namespace Meter_Project.Repository_Layer
{
    public interface IMeterRepository
    {
        public object FindDetailsAtCityLevel(string dateRange);
        public object FindDetailsAtFacilityLevel(string dateRange);
        public object FindDetailsAtBuildingLevel(string dateRange);
        public object FindDetailsAtFloorLevel(string dateRange);
        public object FindDetailsAtZoneLevel(string dateRange);
        public object FindDetailsAtMeterLevel(string dateRange);

    }
}
