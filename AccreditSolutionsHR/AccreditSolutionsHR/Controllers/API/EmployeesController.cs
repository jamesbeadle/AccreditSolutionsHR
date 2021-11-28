using AccreditSolutionsHR.Models;
using AccreditSolutionsHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccreditSolutionsHR.Controllers.API
{
    [RoutePrefix("api/Employees")]
    public class EmployeesController : ApiController
    {
        readonly IEmployeeManager employeeManager;
        public EmployeesController(EmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }


        [Route("GetEmployees")]
        [HttpGet]
        public List<EmployeeTableRowVM> GetEmployees()
        {
            return employeeManager.GetPaginatedList(1, 10).ToList();
        }
        
        [Route("GetEmployee")]
        [HttpGet]
        public Employee Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return employeeManager.GetById((int)id);

        }

        [Route("CreateEmployee")]
        [HttpPost]
        public Employee Create(Employee employee)
        {
            employeeManager.Add(employee);
            return employee;
        }

        [Route("UpdateEmployee")]
        [HttpPost]
        public Employee Update(Employee employee)
        {
            employeeManager.Update(employee);
            return employee;
        }

        [Route("DeleteEmployee")]
        [HttpPost]
        //delete
        public void Delete(int? id)
        {
            employeeManager.Delete(id);
        }


    }
}
