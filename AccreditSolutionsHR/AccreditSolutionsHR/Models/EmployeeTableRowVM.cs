using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccreditSolutionsHR.Models
{
    public class EmployeeTableRowVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public string EmployeeNumber { get; set; }
    }
}