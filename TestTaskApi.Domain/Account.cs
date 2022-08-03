using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Api.Domain
{
    public class Account
    {
        public Account()
        {
            this.Cards=new HashSet<Card>();
        }
       
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string NumberAccount { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}