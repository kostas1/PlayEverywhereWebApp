using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayEv.Model.Entities;

namespace PlayEv.Model.Abstract
{
    public interface IInviteRepository
    {
        IQueryable<Invite> Invites { get; }
    }
}
