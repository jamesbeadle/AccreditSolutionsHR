//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccreditSolutionsHR
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HRModelContainer : DbContext
    {
        public HRModelContainer()
            : base("name=HRModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Status> Status { get; set; }
    
        public virtual int sp_GetEmployees(Nullable<int> page, Nullable<int> size, string sort, ObjectParameter totalrow)
        {
            var pageParameter = page.HasValue ?
                new ObjectParameter("page", page) :
                new ObjectParameter("page", typeof(int));
    
            var sizeParameter = size.HasValue ?
                new ObjectParameter("size", size) :
                new ObjectParameter("size", typeof(int));
    
            var sortParameter = sort != null ?
                new ObjectParameter("sort", sort) :
                new ObjectParameter("sort", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_GetEmployees", pageParameter, sizeParameter, sortParameter, totalrow);
        }
    }
}
