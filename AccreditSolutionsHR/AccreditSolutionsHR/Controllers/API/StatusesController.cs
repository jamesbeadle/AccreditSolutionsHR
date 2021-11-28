using AccreditSolutionsHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccreditSolutionsHR.Controllers.API
{
    [RoutePrefix("api/Statuses")]
    public class StatusesController : ApiController
    {
        readonly IStatusManager statusManager;
        public StatusesController(StatusManager statusManager)
        {
            this.statusManager = statusManager;
        }


        [Route("GetStatuses")]
        [HttpGet]
        public List<Status> GetStatuses()
        {
            return statusManager.GetAll().ToList();
        }
        
        [Route("GetStatus")]
        [HttpGet]
        public Status Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return statusManager.GetById((int)id);

        }

        [Route("CreateStatus")]
        [HttpPost]
        public void Create(Status status)
        {
            statusManager.Add(status);
        }

        [Route("UpdateStatus")]
        [HttpPost]
        public Status Update(Status status)
        {
            statusManager.Update(status);
            return status;
        }

        [Route("DeleteStatus")]
        [HttpPost]
        //delete
        public void Delete(int? id)
        {
            statusManager.Delete(id);
        }


    }
}
