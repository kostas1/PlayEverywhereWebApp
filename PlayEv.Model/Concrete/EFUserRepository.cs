using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayEv.Model.Abstract;

namespace PlayEv.Model.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Entities.User> Users
        {
            get { return context.Users; }
        }


        public void CreateUser(Entities.User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
