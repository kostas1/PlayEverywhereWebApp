﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using PlayEv.Model.Entities;

namespace PlayEv.Model.Concrete
{
    class EFDbContext:DbContext
    {
        public DbSet<User> Users { get;set;}
        public DbSet<Game> Games { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Invite> Invites { get; set; }
    }
}
