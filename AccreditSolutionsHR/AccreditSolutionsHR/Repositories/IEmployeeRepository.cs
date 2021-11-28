using AccreditSolutionsHR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AccreditSolutionsHR.Repositories
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<EmployeeTableRowVM> GetPaginatedList(int page, int recordsPerPage, Dictionary<string, int[]> filters, int orderColumn, int orderDirection);
        int GetRecordCount(Dictionary<string, int[]> filters);
        Employee GetByID(object id);
        void Insert(Employee entity);
        void Delete(object id);
        void Update(Employee entityToUpdate);
        void Save();
        void Dispose(bool disposing);
    }
}
