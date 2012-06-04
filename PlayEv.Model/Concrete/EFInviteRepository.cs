using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayEv.Model.Abstract;

namespace PlayEv.Model.Concrete
{
    class EFInviteRepository:IInviteRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Entities.Invite> Invites
        {
            get { return context.Invites; }
        }
    }
}
