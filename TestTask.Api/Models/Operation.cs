using System;

namespace TestTask.Api.Models
{
    public class Operation
    {
        public Guid Id { get; set; }

        public DateTime TimeOperation { get; set; }
       
        public Card Card { get; set; }

        public Payment Payment { get; set; }

        public decimal SumOperation { get; set; }
    }
}
