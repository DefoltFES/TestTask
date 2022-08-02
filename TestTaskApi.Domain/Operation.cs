using System;

namespace TestTask.Api.Domain
{
    public class Operation
    {
        public Guid Id { get; set; }

        public DateTime TimeOperation { get; set; }

        public Guid CardId { get; set; }
        public  Card Card { get; set; }

        public Guid PaymentId { get; set; }
        public  Payment Payment { get; set; }

        public decimal SumOperation { get; set; }
    }
}
