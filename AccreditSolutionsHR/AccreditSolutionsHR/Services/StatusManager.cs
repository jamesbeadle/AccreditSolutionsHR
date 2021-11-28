using AccreditSolutionsHR.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccreditSolutionsHR.Services
{
    public class StatusManager : IStatusManager
    {
        readonly IGenericRepository<Status> statusRepository;

        public StatusManager(GenericRepository<Status> statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        public void Add(Status status)
        {
            statusRepository.Insert(status);
            statusRepository.Save();
        }

        public void Delete(int? id)
        {
            statusRepository.Delete(id);
            statusRepository.Save();
        }

        public IEnumerable<Status> GetAll()
        {
            return statusRepository.Get();
        }

        public Status GetById(int? id)
        {
            return statusRepository.GetByID(id);
        }

        public void Update(Status status)
        {
            statusRepository.Update(status);
            statusRepository.Save();
        }
    }
}