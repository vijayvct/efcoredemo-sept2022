using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace FirstEFCoreDemo.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(70)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Location { get; set; }

        //Navigation Property
        public IEnumerable<Book> Books { get; set; }
    }
}