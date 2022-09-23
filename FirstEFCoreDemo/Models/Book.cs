using System;
using System.ComponentModel.DataAnnotations;

namespace FirstEFCoreDemo.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Price {get;set;}

        //Foreign Key Property
        public int AuthorId { get; set; }

        //Navigation Property
        public Author Author { get; set; }
    }
}