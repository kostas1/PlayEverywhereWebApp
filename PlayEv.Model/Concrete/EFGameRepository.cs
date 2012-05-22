using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayEv.Model.Abstract;
using PlayEv.Model.Entities;

namespace PlayEv.Model.Concrete
{
    public class EFGameRepository : IGameRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Entities.Game> Games
        {
            get { return context.Games; }
        }


        public void SubmitGame(Entities.Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
        }


        public IEnumerable<string> GetCategories()
        {
            return context.Games.Select(m => m.Category).Distinct().OrderBy(n => n);

        }
    }
}
