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
       IQueryable<User> Friends(int userId);
       bool AddFriend(string myUsername, string friendUsername);
    }
}
