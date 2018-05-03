using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class FinishedPickups
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="FinishedDates")]
        public string FinishedDates { get; set; }

    }
}