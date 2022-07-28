using System.Collections.Generic;

namespace Meter_Project.Models
{
    public class responseModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public ICollection<Facility> facilities { get; set; }
        public ICollection<Building> buildings { get; set; }
        public ICollection<Floor> floors { get; set; }
        public ICollection<Zone> zones { get; set; }
        public ICollection<Meter> meters { get; set; }
    }
}
