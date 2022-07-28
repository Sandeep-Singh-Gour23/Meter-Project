using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meter_Project.Models
{
    public class Zone
    {
        [Key]
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public Floor Floor { get; set; }
        public ICollection<Meter> meters { get; set; }

    }
}
