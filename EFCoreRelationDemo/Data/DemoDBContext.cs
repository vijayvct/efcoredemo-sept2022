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

      public DbSet<Student> Students { get; set; }
      public DbSet<Course> Courses { get; set; }
      public DbSet<StudentCourse> StudentCourses { get; set; }

      //Configuring Connnection String
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder
            .UseSqlServer("data source=CTAADPG02MWBG;initial catalog=EFRelationDB;user id=sa;password=Password_123");
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         //Setting up Primary Key 
         //modelBuilder.Entity<Publisher>().HasKey(p=>p.PubId);

         //One to One 
         // //modelBuilder.Entity<Employee>()
         //             .HasOne(p=>p.EmployeeAddress)
         //             .WithOne(e=>e.Employee)
         //             .HasForeignKey<EmployeeAddress>(s=>s.EmployeeId);

         //One to Many 
         // modelBuilder.Entity<Book>()
         //             .HasOne<Publisher>(p=>p.Publisher)
         //             .WithMany(b=>b.Books)
         //             .HasForeignKey(d=>d.PubId);

         //Many to Many 

         //Creating a Composite Key 
         modelBuilder.Entity<StudentCourse>()
            .HasKey(s=> new {s.StudentId,s.CourseId});

         modelBuilder.Entity<StudentCourse>()
                     .HasOne<Student>(s=>s.Student)
                     .WithMany(c=>c.StudentCourses)
                     .HasForeignKey(sc=>sc.StudentId);

         modelBuilder.Entity<StudentCourse>()
                     .HasOne<Course>(c=>c.Course)
                     .WithMany(s=>s.StudentCourses)
                     .HasForeignKey(sc=>sc.CourseId);
      }
   }
}