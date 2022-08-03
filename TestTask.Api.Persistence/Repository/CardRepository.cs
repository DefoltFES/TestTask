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
            _context.Cards.Add(card);
            _context.SaveChanges();
        }

        public void AddMany(ICollection<Card> cards)
        {
            _context.Cards.AddRange(cards);
        }

        public void Delete(string numberCard)
        {
            var card = _context.Cards.Where(x => x.Number == numberCard).FirstOrDefault();
            if (card != null)
            {
                _context.Cards.Remove(card);               
            }
            
        }
        public Card Get(string numberCard)
        {
            return _context.Cards.Where(x => x.Number == numberCard).FirstOrDefault();
        }

      
    }
}
