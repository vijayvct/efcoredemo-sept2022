using System;
using EFInheritanceDemo.Data;
using EFInheritanceDemo.Models;

namespace EFInheritanceDemo
{
    public class Program 
    {
        static void Main(string[] args)
        {
            MyContext context= new MyContext();

            var student = new Student{Name="Malcolm",EnrollmentDate=DateTime.Now};
            var teacher = new Teacher{Name="James",HireDate=DateTime.Now};

            context.AddRange(student,teacher);
            context.SaveChanges();

            Console.WriteLine("Record Added");
        }
    }
}