using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeRegistry.Models
{
    public class EmployeeCreateRequest
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(14)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(5)]
        public string Zipcode { get; set; }
        [Required, MaxLength(10)]
        public string HireDate { get; set; }
    }
}