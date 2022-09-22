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
    }
}