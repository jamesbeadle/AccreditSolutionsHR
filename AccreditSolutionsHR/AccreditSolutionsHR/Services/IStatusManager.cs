using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccreditSolutionsHR.Services
{
    interface IStatusManager
    {
        IEnumerable<Status> GetAll();
        Status GetById(int? id);
        void Add(Status employee);
        void Delete(int? id);
        void Update(Status employee);
    }
}
