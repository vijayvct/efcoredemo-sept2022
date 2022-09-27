using System;
using System.Collections.Generic;

namespace EFCoreRelationDemo.Models
{
    //One to Many Relationship between Employee and Department
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property
        public IEnumerable<Employee> Employees{get;set;}
    }

    //One to One Relationship between Employee and EmployeeAddress
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Foreign Key
        public int DepartmentId { get; set; }

        //Navigation Property 
        public EmployeeAddress EmployeeAddress  { get; set; }

        public Department Department { get; set; }
    }

    public class EmployeeAddress
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }

        //Foreign Key 
        public int EmployeeId { get; set; }

        //Navigation Property
        public Employee Employee { get; set; }
    }
}