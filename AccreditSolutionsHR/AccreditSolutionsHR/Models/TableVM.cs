using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccreditSolutionsHR.Models
{
    public class TableVM<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Page { get; set; }
        public int ResultsPerPage { get; set; }
        public int PageCount { get; set; }
    }
}