using System;
using System.Linq;
using System.Collections.Generic;
using FirstEFCoreDemo.Models;
using FirstEFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstEFCoreDemo
{
    class Program02
    {
        private static AppDBContext context = new AppDBContext();
        static void RawSQL_1()
        {
            var authors = context.Authors.FromSqlRaw("select * from Authors").ToList();

            foreach(var author in authors)
            {
                Console.WriteLine($"{author.AuthorId},{author.LastName}");
            }
        }

        static void RawSQL_2()
        {
            var location ="India";
            var filterdata= "%a%";

            var authors = context.Authors
                .FromSqlRaw("select * from Authors where location = {0} and LastName like {1}",location,filterdata);

            foreach(var author in authors)
            {
                Console.WriteLine($"{author.AuthorId},{author.LastName}");
            }
        }

        static void RawSQL_3()
        {
            var location ="India";
            var filterdata= "%a%";

            var authors = context.Authors
                .FromSqlInterpolated($"select * from Authors where location = {location} and LastName like {filterdata}");

            foreach(var author in authors)
            {
                Console.WriteLine($"{author.AuthorId},{author.LastName}");
            }
        }

        static void StoredProcedure()
        {
            var id=111;

            var book=(context.Books.FromSqlInterpolated($"exec GetBook {id}").ToList()).FirstOrDefault();

            if(book==null)
                Console.WriteLine("Book not Found");
            else
                Console.WriteLine($"Id = {book.Id},Title = {book.Title}");
        }
        static void Main(string[] args)
        {
            //RawSQL_1();
            //RawSQL_3();
            StoredProcedure();
        }
    }
}