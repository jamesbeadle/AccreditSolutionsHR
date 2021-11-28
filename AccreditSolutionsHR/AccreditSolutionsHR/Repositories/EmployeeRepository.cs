using AccreditSolutionsHR.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AccreditSolutionsHR.Repositories
{
    public class EmployeeRepository : IDisposable, IEmployeeRepository
    {
        internal HRModelContainer context;
        internal DbSet<Employee> dbSet;

        public EmployeeRepository(HRModelContainer context)
        {
            this.context = context;
            this.dbSet = context.Set<Employee>();
        }

        public IEnumerable<EmployeeTableRowVM> GetPaginatedList(int page, int recordsPerPage, Dictionary<string, int[]> filters, int orderColumn, int orderDirection)
        {
            string statusIdArray = "";
            if(filters["StatusId"] != null)
            {
                foreach (var id in filters["StatusId"])
                {
                    statusIdArray += id + ",";
                }
                statusIdArray = statusIdArray.Length > 0 ? statusIdArray.Substring(0, statusIdArray.Length - 1) : statusIdArray;
            }

            string departmentIdArray = "";
            if (filters["DepartmentId"] != null)
            {
                foreach (var id in filters["DepartmentId"])
                {
                    departmentIdArray += id + ",";
                }
                departmentIdArray = departmentIdArray.Length > 0 ? departmentIdArray.Substring(0, departmentIdArray.Length - 1) : departmentIdArray;
            }

            string sqlQueryString = $"select Id, FirstName + ' ' + LastName AS FullName, DOB," +
                $"(select name from departments where id = DepartmentId) AS Department," +
                $"(select name from Status where id = StatusId) AS Status, EmployeeNumber FROM " +
                $"( SELECT ROW_NUMBER() OVER ( ORDER BY Id ) AS RowNum, Id, FirstName, LastName, DOB, DepartmentId, StatusId, EmployeeNumber FROM Employees ";
            
            if(statusIdArray.Length > 0 || departmentIdArray.Length > 0)
            {
                sqlQueryString += " where ";
                bool multiWhere = false;
                if (statusIdArray.Length > 0)
                {
                    sqlQueryString += $"StatusId in ({statusIdArray})";
                    multiWhere = true;
                }
                if(departmentIdArray.Length > 0)
                {
                    sqlQueryString += (multiWhere) ? " AND " : "";
                    sqlQueryString += $"DepartmentId in ({departmentIdArray})";
                }
            }

            int rowStart = (page - 1) * recordsPerPage;
            int rowEnd = rowStart + 1 + recordsPerPage;

            sqlQueryString += $") AS RowConstrainedResult WHERE RowNum > {rowStart} AND RowNum < {rowEnd}";

            string orderBySQL = " ORDER BY RowNum";
            //add order by for columns
            switch (orderColumn)
            {
                case 1:
                    orderBySQL = (orderDirection == 1) ? " ORDER BY LastName" : " ORDER BY LastName Desc";
                    break;
                case 2:
                    orderBySQL = (orderDirection == 1) ? " ORDER BY DOB" : " ORDER BY DOB Desc";
                    break;
                case 3:
                    orderBySQL = (orderDirection == 1) ? " ORDER BY DEPARTMENT" : " ORDER BY DEPARTMENT Desc";
                    break;
                case 4:
                    orderBySQL = (orderDirection == 1) ? " ORDER BY STATUS" : " ORDER BY STATUS Desc";
                    break;
                case 5:
                    orderBySQL = (orderDirection == 1) ? " ORDER BY EMPLOYEENUMBER" : " ORDER BY EMPLOYEENUMBER Desc";
                    break;
                default:
                    break;
            }

            sqlQueryString += orderBySQL;

            using (var ctx = new HRModelContainer())
            {
                
                return ctx.Database.SqlQuery<EmployeeTableRowVM>(sqlQueryString).ToList();
            }
        } 

        public int GetRecordCount(Dictionary<string, int[]> filters)
        {
            string statusIdArray = "";
            if (filters["StatusId"] != null)
            {
                foreach (var id in filters["StatusId"])
                {
                    statusIdArray += id + ",";
                }
                statusIdArray = statusIdArray.Length > 0 ? statusIdArray.Substring(0, statusIdArray.Length - 1) : statusIdArray;
            }

            string departmentIdArray = "";
            if (filters["DepartmentId"] != null)
            {
                foreach (var id in filters["DepartmentId"])
                {
                    departmentIdArray += id + ",";
                }
                departmentIdArray = departmentIdArray.Length > 0 ? departmentIdArray.Substring(0, departmentIdArray.Length - 1) : departmentIdArray;
            }

            string sqlQueryString = $"select COUNT(*) FROM Employees ";

            if (statusIdArray.Length > 0 || departmentIdArray.Length > 0)
            {
                sqlQueryString += " where ";
                bool multiWhere = false;
                if (statusIdArray.Length > 0)
                {
                    sqlQueryString += $"StatusId in ({statusIdArray})";
                    multiWhere = true;
                }
                if (departmentIdArray.Length > 0)
                {
                    sqlQueryString += (multiWhere) ? " AND " : "";
                    sqlQueryString += $"DepartmentId in ({departmentIdArray})";
                }
            }

            using (var ctx = new HRModelContainer())
            {
                return ctx.Database.SqlQuery<int>(sqlQueryString).ToList().FirstOrDefault();
            }
        }

        public virtual Employee GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(Employee entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            Employee entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(Employee entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(Employee entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public virtual void Save()
        {
            context.SaveChanges();
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
