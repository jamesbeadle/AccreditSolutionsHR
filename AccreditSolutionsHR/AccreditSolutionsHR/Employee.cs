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
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public System.DateTime DOB { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeNumber { get; set; }
        public int StatusId { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Status Status { get; set; }
    }
}