using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayEv.Model.Entities;

namespace PlayEv.Model.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void CreateUser(User user);
        IEnumerable<User> Friends(int userId);
        bool AddFriend(int myId, string friendUsername);
        void RemoveFriend(int userId, int friendId);
    }
}
