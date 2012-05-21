using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayEv.Model.Abstract;

namespace PlayEv.Model.Concrete
{
    public class EFGameRepository : IGameRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Entities.Game> Games
        {
            get { return context.Games; }
        }
    }
}
