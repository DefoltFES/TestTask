using System;

namespace TestTask.Api.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public Account Account { get; set; }
    }
}