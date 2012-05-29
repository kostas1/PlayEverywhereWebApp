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

        public IQueryable<User> Users
        {
            get { return context.Users; }
        }

        public void CreateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public IQueryable<User> Friends(int userId)
        {
            int[] friends = (from f in context.Friends where f.Myid == userId select f.Friendid).ToArray();
            var friendProfiles = from fP in context.Users
                                 where friends.Any(x => x == fP.Id)
                                 select new User()
                                 {
                                     Username = fP.Username,
                                     Id = fP.Id,
                                     BirthDate = fP.BirthDate
                                 };
            return friendProfiles;
        }

        public bool AddFriend(string myUsername, string friendUsername)
        {
            User friend = (from f in context.Users where f.Username == friendUsername select f).FirstOrDefault();
            User me = (from m in context.Users where m.Username == myUsername select m).FirstOrDefault();

            if (friend != null)
            {
                context.Friends.Add(new FriendRelation() { Myid = me.Id, Friendid = friend.Id });
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
