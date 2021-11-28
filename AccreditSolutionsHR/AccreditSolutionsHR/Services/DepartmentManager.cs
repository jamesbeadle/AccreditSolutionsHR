using AccreditSolutionsHR.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccreditSolutionsHR.Services
{
    public class DepartmentManager : IDepartmentManager
    {
        readonly IGenericRepository<Department> departmentRepository;

        public DepartmentManager(GenericRepository<Department> departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public void Add(Department department)
        {
            departmentRepository.Insert(department);
            departmentRepository.Save();
        }

        public void Delete(int? id)
        {
            departmentRepository.Delete(id);
            departmentRepository.Save();
        }

        public IEnumerable<Department> GetAll()
        {
            return departmentRepository.Get();
        }

        public Department GetById(int? id)
        {
            return departmentRepository.GetByID(id);
        }

        public void Update(Department department)
        {
            departmentRepository.Update(department);
            departmentRepository.Save();
        }
    }
}