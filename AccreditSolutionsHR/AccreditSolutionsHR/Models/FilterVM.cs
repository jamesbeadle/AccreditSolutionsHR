using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccreditSolutionsHR.Models
{
    public class FilterVM
    {
        public int[] DepartmentIds { get; set; }
        public int[] StatusIds { get; set; }
        public int Page { get; set; }
        public int ResultsPerPage { get; set; }
        public int OrderColumn { get; set; }
        public int OrderDirection { get; set; }
    }
}