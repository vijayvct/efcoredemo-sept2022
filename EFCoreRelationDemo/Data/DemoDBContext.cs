using System;
using EFCoreRelationDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationDemo.Data
{
   public class DemoDBContext:DbContext
   {

      //DbSet 
      public DbSet<Employee> Employeess { get; set; }
      public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }

      public DbSet<Publisher> Publishers{get;set;}
      public DbSet<Book> Books { get; set; }

      //Configuring Connnection String
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder
            .UseSqlServer("data source=CTAADPG02MWBG;initial catalog=EFRelationDB;user id=sa;password=Password_123");
      }
   }
}