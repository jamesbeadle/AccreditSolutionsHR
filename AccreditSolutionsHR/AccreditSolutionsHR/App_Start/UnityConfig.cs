using AccreditSolutionsHR.Repositories;
using AccreditSolutionsHR.Services;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Unity.WebApi;

namespace AccreditSolutionsHR
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //register services
            container.RegisterType<IEmployeeManager, EmployeeManager>();
            container.RegisterType<IDepartmentManager, DepartmentManager>();
            container.RegisterType<IStatusManager, StatusManager>();

            //register DAL repositories
            container.RegisterType<IGenericRepository<Employee>, GenericRepository<Employee>>();
            container.RegisterType<IGenericRepository<Department>, GenericRepository<Department>>();
            container.RegisterType<IGenericRepository<Status>, GenericRepository<Status>>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}