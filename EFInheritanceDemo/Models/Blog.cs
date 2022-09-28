using System;
using System.ComponentModel.DataAnnotations;

namespace EFInheritanceDemo.Models
{
    //TPT
    
    //Abstract Class 
    public abstract class BlogBase
    {   
        [Key]
        public int BlogId { get; set; }
    }

    public class Blog:BlogBase
    {
        public string? Url { get; set; }
    }

    public class RssBlog:BlogBase
    {
        public string? Url { get; set; }
    }
}