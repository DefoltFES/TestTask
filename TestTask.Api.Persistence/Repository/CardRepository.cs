using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Application.Interfaces;
using TestTask.Api.Domain;

namespace TestTask.Api.Persistence.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly TestTaskDbContext _context;

        public CardRepository(TestTaskDbContext context)
        {
            _context = context;
        }

        public void Add(Card card)
        {
            throw new NotImplementedException();
        }

        public void AddMany(ICollection<Card> cards)
        {
            throw new NotImplementedException();
        }

        public void Delete(string numberCard)
        {
            throw new NotImplementedException();
        }

        public Card Get(string numberCard)
        {
            return _context.Cards.Where(x => x.Number == numberCard).FirstOrDefault();
        }

      
    }
}
