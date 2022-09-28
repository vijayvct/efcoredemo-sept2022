using System;
using Microsoft.EntityFrameworkCore;
using EFInheritanceDemo.Models;

namespace EFInheritanceDemo.Data
{
    public class MyContext:DbContext
    {
        //DbSet
        public DbSet<Person> People { get; set; }

        public DbSet<BlogBase> Blogs { get; set; }

        public DbSet<BillingDetail> BillingDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer("data source=CTAADPG02MWBG;initial catalog=UniversityDB;integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TPH
            modelBuilder.Entity<Teacher>().HasBaseType<Person>();
            modelBuilder.Entity<Student>().HasBaseType<Person>();

            //TPT
            modelBuilder.Entity<Blog>().Property(b=>b.Url).HasColumnName("BlogURL");
            modelBuilder.Entity<RssBlog>().Property(b=>b.Url).HasColumnName("RssURL");

            modelBuilder.Entity<Blog>().ToTable("SampleBlogs");
            modelBuilder.Entity<RssBlog>().ToTable("RssBlogs");

            //TPC
            // modelBuilder.Entity<BankAccount>().Map(m=>{
            //     m.Map
            //  })
        }
    }
}