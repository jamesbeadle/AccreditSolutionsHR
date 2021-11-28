using System.Collections.Generic;

namespace AccreditSolutionsHR.Services
{
    public interface IDepartmentManager
    {
        IEnumerable<Department> GetAll();
        Department GetById(int? id);
        void Add(Department department);
        void Delete(int? id);
        void Update(Department department);

    }
}