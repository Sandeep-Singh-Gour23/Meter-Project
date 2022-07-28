using System;
using System.ComponentModel.DataAnnotations;

namespace Meter_Project.Models
{
    public class Meter
    {
        [Key]
        public int MeterId { get; set; }
        public string MeterType { get; set; }
        public bool IsActive { get; set; }
        public long? CurrentReading { get; set; }
        public DateTime InstalledAt { get; set; }
        public Zone Zone { get; set; }

    }
}
