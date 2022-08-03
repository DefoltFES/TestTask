using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Application.Interfaces;
using TestTask.Api.Domain;

namespace TestTask.Api.Persistence.Repository
{
    public class FavoriteRepository:IFavoriteReposiory
    {
        private readonly TestTaskDbContext _context;

        public FavoriteRepository(TestTaskDbContext context)
        {
            _context = context;
        }

        public void Add(Favorite favorite)
        {
            favorite.Id=Guid.NewGuid();
            _context.Favorites.Add(favorite);
            _context.SaveChanges();
        }

        public void AddMany(ICollection<Favorite> favorites)
        {
            favorites.ToList().ForEach(x => x.Id = Guid.NewGuid());
            _context.Favorites.AddRange(favorites);
            _context.SaveChanges();
        }

        public void Edit(Favorite favorite)
        {
            _context.Favorites.Update(favorite);
            _context.SaveChanges();
        }


        public ICollection<Favorite> GetAll()
        {
            return _context.Favorites.ToList();
        }

        public void Remove(Guid item)
        {
            var fav = _context.Favorites.Where(x => x.Id == item).FirstOrDefault();
            if (fav != null)
            {
                _context.Favorites.Remove(fav);
                _context.SaveChanges();
            } 
        }

    }
}
