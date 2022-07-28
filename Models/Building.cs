using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meter_Project.Models
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public Facility Facility { get; set; }
        public ICollection<Floor> floors { get; set; }
    }
}
