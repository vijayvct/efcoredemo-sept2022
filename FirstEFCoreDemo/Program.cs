using System;
using FirstEFCoreDemo.Models;
using FirstEFCoreDemo.Data;
using System.Collections.Generic;

namespace FirstEFCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating Database Context 
            AppDBContext context = new AppDBContext();

            Console.WriteLine("Press Enter to create database");
            Console.ReadLine();
            
            if(context.Database.EnsureCreated())
                Console.WriteLine("\nDatabase Created");
            else
                Console.WriteLine("\nUnable to Create Database");

            //Enter records in the table 
            Console.WriteLine("\n\nPress Enter to add records to the table");
            Console.ReadLine();

            List<Employee> employees= new List<Employee>
            {
                new Employee{Name="James",Designation="Manager"},
                new Employee{Name="Malcolm",Designation="Sr Developer"},
                new Employee{Name="Julia",Designation="Trainer"}
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();//to make changes persist to the database

            Console.WriteLine("Employee data added successfully...");

            Console.WriteLine("\n\nPress Enter to display data");
            Console.ReadLine();

            foreach(Employee employee in context.Employees)
            {
                Console.WriteLine($"{employee.EmployeeID},{employee.Name},{employee.Designation}");
            }

            Console.WriteLine("\n\nPress Enter to delete database");
            Console.ReadLine();

            if(context.Database.EnsureDeleted())
                Console.WriteLine("Database Deleted");
            else
                Console.WriteLine("Unable to delete database");
        }
    }
}
 