using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Api.Domain
{
    public class Card
    {
        public  Card()
        {
            Operations=new HashSet<Operation>();
        }
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string Number { get; set; }
        public decimal Balance { get; set; }

        public Guid AccountId { get; set; }
        public  Account Account { get; set; }

        public ICollection<Operation> Operations { get; set; }

    }
}