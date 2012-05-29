using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayEv.Model.Abstract;
using PlayEv.Model.Entities;

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

        public List<Entities.User> Friends(int userId)
        {
            return (List<User>)context.Users.Where(m => m.Id == userId).Select(f => f.Friends.Username);
        }
    }
}
