using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTask.Api.Application.Interfaces;
using TestTask.Api.Domain;
using TestTask.Api.Persistence.Repository;

namespace TestTask.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController:ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        public CardsController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpDelete]
        public void Delete(Card card)
        {
            _cardRepository.Delete(card.Number);
        }

        [HttpPost]

        public void Add(Card card)
        {
            _cardRepository.Add(card);
        }

        [HttpPost("AddMany")]
        public void AddMany(ICollection<Card> cards)
        {
            _cardRepository.AddMany(cards);
        }


       
    }
}
