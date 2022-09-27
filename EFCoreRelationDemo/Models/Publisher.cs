using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelationDemo.Models
{
    public class Publisher
    {
        [Key]
        public int PubId { get; set; }

        public string Name { get; set; }

        //Navigation Property
        public IEnumerable<Book> Books { get; set; }
    }

    public class Book
    {   
        [Key]
        public int BKId { get; set; }
        public string Title { get; set; }

        //Foreign Key
        [ForeignKey("Publisher")]
        public int PubId { get; set; }

        //Navigation Property
        public Publisher Publisher { get; set; }
    }
}