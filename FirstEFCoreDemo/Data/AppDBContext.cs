using System;
using FirstEFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FirstEFCoreDemo.Data
{
    public class AppDBContext:DbContext
    {
        //Creating a variable to store connectionstring
        string conn="data source=CTAADPG02MWBG;initial catalog=LibraryDB;integrated security=true";

        //Creating DBSet
        public DbSet<Employee> Employees {get;set;}

        public DbSet<Author> Authors {get;set;}

        public DbSet<Book> Books { get; set; }

        public DbSet<Customer> Customers {get;set;}

        //Creating a Console Logger
        public static readonly ILoggerFactory ConsoleLoggerFactory=
            LoggerFactory.Create(builder=>
            {
                builder.AddFilter((category,level)=>
                    category==DbLoggerCategory.Database.Command.Name && level==LogLevel.Information
                ).AddConsole();
            });

        //Overridding the OnConfiguring() of DbContext to specify the connectionstring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging()
                 .UseSqlServer(conn);
        }

        //Overridding the OnModelCreating() to seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding Data to tables

            modelBuilder.Entity<Author>().HasData
            (
                new Author{AuthorId=1,FirstName="Vijay",LastName="Vishwakarma",Email="vijayv@citiustech.com",Location="India"},
                new Author{AuthorId=2,FirstName="Bill",LastName="Gates",Email="gatesbill@microsoft.com",Location="US"},
                new Author{AuthorId=3,FirstName="Scott",LastName="Hanselman",Email="scotth@microsoft.com",Location="US"},
                new Author{AuthorId=4,FirstName="J.K",LastName="Rowling",Email="jk@hogwarts.com",Location="UK"}
            );
            modelBuilder.Entity<Book>().HasData
            (
              new Book{Id=1,Title="Sql Server 2019",Price=108.99,AuthorId=2},
              new Book{Id=2,Title="Azure Fundamentals",Price=399.99,AuthorId=3},
              new Book{Id=3,Title="Azure Administration",Price=200.00,AuthorId=3},
              new Book{Id=4,Title="Harry Potter and The Chambers of Secret",Price=899.99,AuthorId=4}  
            );

            modelBuilder.Entity<Employee>().HasData
            (
                new Employee{EmployeeID=1,Name="Malcolm",Designation="Manager"},
                new Employee{EmployeeID=2,Name="James",Designation="SW Engg"}
            );

            modelBuilder.Entity<Customer>().ToTable("Customers",schema:"MySchema");

            //Default Schema Set for all the table
            //modelBuilder.HasDefaultSchema("MySchema");
        }
    }
}