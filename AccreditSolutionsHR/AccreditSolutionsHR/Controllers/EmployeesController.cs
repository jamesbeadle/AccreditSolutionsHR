using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccreditSolutionsHR;
using AccreditSolutionsHR.Models;
using AccreditSolutionsHR.Services;

namespace AccreditSolutionsHR.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeManager employeeManager;
        private readonly IDepartmentManager departmentManager;
        private readonly IStatusManager statusManager;

        public EmployeesController(EmployeeManager employeeManager, DepartmentManager departmentManager, StatusManager statusManager)
        {
            this.employeeManager = employeeManager;
            this.departmentManager = departmentManager;
            this.statusManager = statusManager;
        }

        // GET: Employees
        public ActionResult Index()
        {
            ViewBag.Statuses = statusManager.GetAll();
            ViewBag.Departments = departmentManager.GetAll();
            return View();
        }

        public PartialViewResult GetEmployeePartial(FilterVM filters)
        {
            TableVM<EmployeeTableRowVM> vm = new TableVM<EmployeeTableRowVM>();
            vm.Data = employeeManager.GetPaginatedList(filters.Page, filters.ResultsPerPage, filters.DepartmentIds, filters.StatusIds, filters.OrderColumn, filters.OrderDirection);
            vm.Page = filters.Page;
            vm.ResultsPerPage = filters.ResultsPerPage;
            vm.PageCount = (employeeManager.GetRecordCount(filters.DepartmentIds, filters.StatusIds) + vm.ResultsPerPage - 1) / vm.ResultsPerPage;
            return PartialView("_EmployeesTable", vm);
        }


        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeManager.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(departmentManager.GetAll(), "Id", "Name");
            ViewBag.StatusId = new SelectList(statusManager.GetAll(), "Id", "Name");
            return View(new Employee());
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,DOB,DepartmentId,EmployeeNumber,StatusId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeManager.Add(employee);
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(departmentManager.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.StatusId = new SelectList(statusManager.GetAll(), "Id", "Name", employee.StatusId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeManager.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(departmentManager.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.StatusId = new SelectList(statusManager.GetAll(), "Id", "Name", employee.StatusId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,DOB,DepartmentId,EmployeeNumber,StatusId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeManager.Update(employee);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(departmentManager.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.StatusId = new SelectList(statusManager.GetAll(), "Id", "Name", employee.StatusId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeManager.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
