using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayEv.Model.Entities;

namespace PlayEv.WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password, User users);
    }
}
