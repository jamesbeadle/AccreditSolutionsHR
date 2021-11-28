using AccreditSolutionsHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccreditSolutionsHR.Controllers.API
{
    [RoutePrefix("api/Departments")]
    public class DepartmentsController : ApiController
    {
        readonly IDepartmentManager departmentManager;
        public DepartmentsController(DepartmentManager departmentManager)
        {
            this.departmentManager = departmentManager;
        }


        [Route("GetDepartments")]
        [HttpGet]
        public List<Department> GetDepartments()
        {
            return departmentManager.GetAll().ToList();
        }
        
        [Route("GetDepartment")]
        [HttpGet]
        public Department Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return departmentManager.GetById((int)id);

        }

        [Route("CreateDepartment")]
        [HttpPost]
        public void Create(Department department)
        {
            departmentManager.Add(department);
        }

        [Route("UpdateDepartment")]
        [HttpPost]
        public Department Update(Department department)
        {
            departmentManager.Update(department);
            return department;
        }

        [Route("DeleteDepartment")]
        [HttpPost]
        //delete
        public void Delete(int? id)
        {
            departmentManager.Delete(id);
        }


    }
}
