using System;

namespace EFInheritanceDemo.Models
{
    //TPH

    //Abstract Class
    public abstract class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class Student:Person
    {
        public DateTime EnrollmentDate { get; set; }
    }

    public class Teacher:Person
    {
        public DateTime HireDate { get; set; }
    }
}