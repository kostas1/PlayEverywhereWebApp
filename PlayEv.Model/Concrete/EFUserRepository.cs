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

        public IEnumerable<User> Friends(int userId)
        {
            int[] friends = (from f in context.Friends where f.Id == userId select f.Friendid).ToArray();
            var friendProfiles = from fP in context.Users
                                 where friends.Any(x => x == fP.Id) select fP;

            return friendProfiles;
        }

        public bool AddFriend(int userId, string friendUsername)
        {
            User friend = (from f in context.Users where f.Username == friendUsername select f).FirstOrDefault();

            if (friend != null)
            {
                var fRelation = new Friend() { Id = userId, Friendid = friend.Id };
                context.Friends.Add(fRelation);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveFriend(int userId,int friendId)
        {
            Friend friend = (from f in context.Friends where f.Friendid == friendId && f.Id == userId select f).FirstOrDefault();

            if (friend != null)
            {
                context.Friends.Remove(friend);
                context.SaveChanges();
            }
        }
    }
}
