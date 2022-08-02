using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Domain;

namespace TestTask.Api.Application.Interfaces
{
    public interface ICardRepository
    {
        public void Add(Card card);

        public void Delete(string numberCard);

        public void AddMany(ICollection<Card> cards);

        public Card Get(string numberCard);
    }
}
