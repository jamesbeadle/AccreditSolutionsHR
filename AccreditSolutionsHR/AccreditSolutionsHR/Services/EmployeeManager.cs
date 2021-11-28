using AccreditSolutionsHR.Models;
using AccreditSolutionsHR.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AccreditSolutionsHR.Services
{
    public class EmployeeManager : IEmployeeManager
    {
        readonly IEmployeeRepository employeeRepository;

        public EmployeeManager(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Add(Employee employee)
        {
            employeeRepository.Insert(employee);
            employeeRepository.Save();
        }

        public void Delete(int? id)
        {
            employeeRepository.Delete(id);
            employeeRepository.Save();
        }

        /// <summary>
        /// Get paginated filtered employee data
        /// </summary>
        /// <param name="page">page from results</param>
        /// <param name="resultsPerPage">number of rows per page</param>
        /// <param name="departmentIds">array of included department ids</param>
        /// <param name="statusIds">array of included status ids</param>
        /// <param name="orderColumn">index of column to order</param>
        /// <param name="orderDirection">direction of order column 0 = ascending & 1 = descending</param>
        /// <returns>List of employees</returns>
        public IEnumerable<EmployeeTableRowVM> GetPaginatedList(int page = 1, int resultsPerPage = 10, int[] departmentIds = null, int[] statusIds = null, int orderColumn = 0, int orderDirection = 0)
        {
            Dictionary<string, int[]> filterProperties = new Dictionary<string, int[]>();
            filterProperties.Add("StatusId", statusIds);
            filterProperties.Add("DepartmentId", departmentIds);
            return employeeRepository.GetPaginatedList(page, resultsPerPage, filterProperties, orderColumn, orderDirection);
        }

        public int GetRecordCount(int[] departmentIds = null, int[] statusIds = null)
        {
            Dictionary<string, int[]> filterProperties = new Dictionary<string, int[]>();
            filterProperties.Add("StatusId", statusIds);
            filterProperties.Add("DepartmentId", departmentIds);
            return employeeRepository.GetRecordCount(filterProperties);
        }

        public Employee GetById(int? id)
        {
            return employeeRepository.GetByID(id);
        }

        public void Update(Employee employee)
        {
            employeeRepository.Update(employee);
            employeeRepository.Save();
        }

    }
}