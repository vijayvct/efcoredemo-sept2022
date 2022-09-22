using System;
using FirstEFCoreDemo.Models;
using FirstEFCoreDemo.Data;
using System.Linq;

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
        static void Main(string[] args)
        {
            //AddAuthor();
            //AddMultipleAuthors();
            //ReadAuthors();
            //AuthorUpdate1();
            //AuthorUpdate2();

            DeleteAuthor();
        }
    }
}