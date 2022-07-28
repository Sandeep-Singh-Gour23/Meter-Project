using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meter_Project.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public City City { get; set; }
        public ICollection<Building> buildings { get; set; }

    }
}
