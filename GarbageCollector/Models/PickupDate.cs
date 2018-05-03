using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class PickupDate
    {
        [Key]
        public int Id { get; set; }
        public int Month { get; set; }
        public string DateOfWeek { get; set; }

        
    }
}