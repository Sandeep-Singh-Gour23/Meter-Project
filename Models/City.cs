using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meter_Project.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public ICollection<Facility> facilities { get; set; }
    }
}
