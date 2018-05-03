using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class EmployeePhoneNumber
    {
        [Key]
        public int Id { get; set; }
        public int PhoneNumer { get; set; }
        public int AreaCode { get; set; }

    }
}