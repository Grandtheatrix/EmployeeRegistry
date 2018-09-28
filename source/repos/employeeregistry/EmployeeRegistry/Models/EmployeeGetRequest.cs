using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeRegistry.Models
{
    public class EmployeeGetRequest : EmployeeCreateRequest
    {
        public int Id { get; set; }
    }
}