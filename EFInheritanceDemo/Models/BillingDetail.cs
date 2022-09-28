using System;

namespace EFInheritanceDemo.Models
{
    //TPC

    //Abstact Class 
    public abstract class BillingDetail
    {
        public int BillingDetailId { get; set; }
        public string? Owner { get; set; }
        public string? Number { get; set; }
    }

    //Concerte Classes 
    public class BankAccount:BillingDetail
    {
        public string? BankName { get; set; }
        public string? Swift { get; set; }
    }

    public class CreditCard:BillingDetail
    {
        public int CardType { get; set; }
        public string? ExpiryMonth { get; set; }
        public string? ExpityYear { get; set; }
    }
}