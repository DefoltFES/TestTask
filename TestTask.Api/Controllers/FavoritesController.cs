using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestTask.Api.Application.Interfaces;
using TestTask.Api.Domain;
using TestTask.Api.Persistence.Repository;

namespace TestTask.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoritesController:ControllerBase
    {
        private readonly IFavoriteReposiory _favoriteRepository;
        public FavoritesController(IFavoriteReposiory favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        [HttpDelete("{id}")]
        public void Delete(Guid favoriteId)
        {
            _favoriteRepository.Remove(favoriteId);
        }

        [HttpPut]

        public void Update(Favorite favorite)
        {
            _favoriteRepository.Edit(favorite);
        }

        [HttpPost]

        public void Add(Favorite favorite)
        {
            _favoriteRepository.Add(favorite);
        }

        [HttpPost("AddMany")]

        public void AddMany(ICollection<Favorite> favorites)
        {
            _favoriteRepository.AddMany(favorites);
        }

        [HttpGet]
        public ICollection<Favorite> GetAll()
        {
            return _favoriteRepository.GetAll();
        }
    }
}
