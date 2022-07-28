using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meter_Project.Models
{
    public class Floor
    {
        [Key]
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public Building Building { get; set; }
        public ICollection<Zone> zones { get; set; }
    }
}
