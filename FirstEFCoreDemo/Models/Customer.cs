using System;
using System.ComponentModel.DataAnnotations;

namespace FirstEFCoreDemo.Models
{
    public class Customer
    {
        [Key]
        public int CustID { get; set; }

        public string Name { get; set; }
    }
}