using AccreditSolutionsHR.Models;
using System.Collections.Generic;

namespace AccreditSolutionsHR.Services
{
    public interface IEmployeeManager
    {
        IEnumerable<EmployeeTableRowVM> GetPaginatedList(int page = 1, int resultsPerPage = 10, int[] departmentIds = null, int[] statusIds = null, int orderColumn = 0, int orderDirection = 0);
        int GetRecordCount(int[] departmentIds = null, int[] statusIds = null);
        Employee GetById(int? id);
        void Add(Employee employee);
        void Delete(int? id);
        void Update(Employee employee);
    }
}