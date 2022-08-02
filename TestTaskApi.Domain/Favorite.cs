using System;

namespace TestTask.Api.Domain
{
    public class Favorite
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid PaymentId { get; set; }
        public  Payment Payment { get; set; }
    }
}
