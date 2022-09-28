using System;
using System.Collections.Generic ;
using EFReverseEnggDemo.Data;
using EFReverseEnggDemo.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFReverseEnggDemo
{
    class Program
    {
        static void EagerLoading()
        {
            var context = new MusicStoreDBContext();

            var customers = context.Customers
                            .Include(c=>c.Invoices)
                            .ThenInclude(c=>c.InvoiceLines)
                            .Where(c=>c.FirstName.StartsWith("A"));

            foreach(var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");

                foreach(var invoice in customer.Invoices)
                {
                    Console.WriteLine($"\t\t{invoice.InvoiceDate} {invoice.Total}") ;
                }
            }
        }

        static void ExplicitLoading()
        {
            var context = new MusicStoreDBContext();

            var tracks = context.Tracks.Take(5).ToList();

            foreach(var track in tracks)
            {
                context.Entry(track).Reference(t=>t.Album).Load();
                context.Entry(track.Album).Reference(t=>t.Artist).Load();

                Console.WriteLine("Album = {0}, Track = {1}, Artist = {2}",
                    track.Album.Title,track.Name,track.Album.Artist.Name);
            }
        }

        static void LazyLoading()
        {
            var context = new MusicStoreDBContext();

            var albums = context.Albums.Take(5).ToList();

            foreach(var album in albums)
            {
                Console.WriteLine($"{album.Title}");

                foreach(var track in album.Tracks)
                {
                    Console.WriteLine($"\t\t{track.Name}");
                }
            }
        }
        static void Main(string[] args)
        {
            //EagerLoading();
            //ExplicitLoading();
            LazyLoading();
        }
    }
}