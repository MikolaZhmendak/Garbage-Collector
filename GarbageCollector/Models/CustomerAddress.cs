using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class CustomerAddress
    {
        [Key]
        public int Id { get; set; }
        public string CustomerMainAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public int CustomerZipCode { get; set; }


    }
}