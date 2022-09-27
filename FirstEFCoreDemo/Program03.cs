using System;
using FirstEFCoreDemo.Models;
using FirstEFCoreDemo.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FirstEFCoreDemo
{
    class Program03
    {
        //Connected Architecture
        static void ConnectedOperations()
        {
            AppDBContext context = new AppDBContext();

            //Adding a author
            var author = new Author
            {
                FirstName="Scott",LastName="Tigers",Email="scott@oracle.com",Location="US"
            };

            Console.WriteLine("Author State before adding = "+context.Entry(author).State);

            context.Authors.Add(author);
            Console.WriteLine("Author State after adding = "+context.Entry(author).State); //Added
            context.SaveChanges();

            //Retreiving authors data
            var authorList= context.Authors.ToList();

            //Updating Authors FirstName 
            foreach(var a in authorList)
            {
                a.FirstName= "Edited "+a.FirstName;
                Console.WriteLine("Update Author State = "+context.Entry(a).State);//Modified
            }
            context.SaveChanges();

            //Deleting an entity 
            var deleteAuthor = context.Authors.Find(9);
            context.Authors.Remove(deleteAuthor);
            Console.WriteLine("Deleted Author State = "+context.Entry(deleteAuthor).State);//Deleted
            context.SaveChanges();
        }

        //Disconnected Architecture
        static void DisconnectedOperations()
        {
            //Fetch the record for update 
            AppDBContext context = new AppDBContext();
            var updateBook = context.Books.Find(3);

            Console.WriteLine("Current State of Book = "+context.Entry(updateBook).State);

            updateBook.Title="AZ-104 Azure Administration";

            //using another context object to update the data 
            using(var updateContext = new AppDBContext())
            {
                Console.WriteLine("New State of book before updating = "
                +updateContext.Entry(updateBook).State);

                updateContext.Attach(updateBook);
                updateContext.Entry(updateBook).State = EntityState.Modified;

                Console.WriteLine("New State of book after updating = "
                +updateContext.Entry(updateBook).State);
                updateContext.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            //ConnectedOperations();
            DisconnectedOperations();
        }
    }
}