using System;
using FirstEFCoreDemo.Models;
using FirstEFCoreDemo.Data;
using System.Linq;
using System.Collections.Generic;

namespace FirstEFCoreDemo
{
    class Program01
    {
        //Creating database context object
        private static AppDBContext context= new AppDBContext();

        //Adding a Single Author 
        static void AddAuthor()
        {
            var author = new Author
            {
                FirstName="Vijay",
                LastName="Vishwakarma",
                Email="vijay.vishwakarma@citiustech.com"
            };

            context.Authors.Add(author);
            context.SaveChanges();

            Console.WriteLine("Author Record Added Successfully....");
        }

        //Adding Multiple Authors
        static void AddMultipleAuthors()
        {
            var author1=new Author{
                FirstName="Bill",
                LastName="Gates",
                Email="bill.gates@microsoft.com",
                Location="US"
            };

            var author2=new Author{
                FirstName="Scott",
                LastName="Hanselman",
                Email="scott.hanselman@microsoft.com",
                Location="US"
            };

            var author3= new Author{
                FirstName="Jonane",
                LastName="Rowling",
                Email="jkrowling@hogwarts.com",
                Location="UK"
            };

            var emp = new Employee();
            context.Authors.AddRange(author1,author2,author3);
            //context.AddRange(author1,author2,author3,emp);
            context.SaveChanges();

            Console.WriteLine("Authors Added Successfully.....");
        }

        //Reading the Author data
        static void ReadAuthors()
        {
            // var authors = from auth in context.Authors
            //               select auth;

            // foreach(var author in authors)
            // {
            //     Console.WriteLine($"{author.AuthorId},{author.FirstName},{author.LastName},"+
            //     $"{author.Email},{author.Location}");
            // }

            foreach(var author in context.Authors)
            {
                Console.WriteLine($"{author.AuthorId},{author.FirstName},{author.LastName},"+
                $"{author.Email},{author.Location}");
            }
        }

        //Updating Author
        static void AuthorUpdate1()
        {
            //LINQ query to search Author
            var author = (from a in context.Authors
                         where a.AuthorId==1
                         select a).FirstOrDefault();

            author.Location="India";
            context.SaveChanges();

            Console.WriteLine("Author Update successfully");
        }

        static void AuthorUpdate2()
        {
            var author = (context.Authors.Where(a=>a.AuthorId==4)).FirstOrDefault();

            author.FirstName="J.K.";
            context.Authors.Update(author);
            context.SaveChanges();

            Console.WriteLine("Author Updated Successfully");
        }

        //Deleting Author 
        static void DeleteAuthor()
        {
            var author = context.Authors.Find(1);

            context.Authors.Remove(author);
            context.SaveChanges();

            Console.WriteLine("Author Deleted....");
        }

        //Reading Books 
        static void ReadBooks()
        {
            foreach(var book in context.Books)
            {
                Console.WriteLine($"{book.Id},{book.Title},{book.Price},{book.AuthorId}");
            }
        }

        static void AddAuthor1()
        {
            try
            {
                var author = new Author
                {
                    FirstName="Malcolm",
                    LastName=null,
                    Email=null,
                    Location="India"
                };

                context.Authors.Add(author);
                context.SaveChanges();

                Console.WriteLine("Author Added");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Caught");
                Console.WriteLine(ex.Message);
            }
        }

        //Inserting Related Data
        static void AuthorBookAdd_1()
        {
            var author = new Author
            {
                FirstName="Malcolm",
                LastName="D",
                Email="malcolm@gmail.com",
                Location="India"
            };

            var book1 = new Book {Title="Oracle DB Fundamentals",Price=199.99,AuthorId=6};
            var book2= new Book{ Title="Azure SQL Adminstration",Price=299.99,AuthorId=6};

            context.AddRange(author,book1,book2);
            context.SaveChanges();

            Console.WriteLine("Details Added Successfully......");
        }

        static void AuthorBookAdd_2()
        {
            var author= new Author
            {
                FirstName="Seema",
                LastName="Sharma",
                Email ="seemas@gmail.com",
                Location="India",
                Books = new List<Book>{
                    new Book {Title="C#",Price=99.99},
                    new Book {Title="VB.Net",Price=29.99}
                }
            };

            context.Add(author);
            context.SaveChanges();

            Console.WriteLine("Record Added....");
        }

        static void Main(string[] args)
        {
            //AddAuthor();
            //AddMultipleAuthors();
            //ReadAuthors();
            //AuthorUpdate1();
            //AuthorUpdate2();
            //DeleteAuthor();

            //ReadBooks();
            //AddAuthor1();
            AuthorBookAdd_2();
        }
    }
}