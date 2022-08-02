using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Api.Domain;

namespace TestTask.Api.Application.Interfaces
{
    public interface IFavoriteReposiory
    {
        public void Add(Favorite favorite);

        public void Update(Favorite favorite);

        public void Remove(Favorite favorite);

        public void Edit(Favorite favorite);


    }
}
