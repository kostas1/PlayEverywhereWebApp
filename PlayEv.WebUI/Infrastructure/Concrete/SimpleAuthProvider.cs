using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlayEv.WebUI.Infrastructure.Abstract;
using PlayEv.Model.Entities;
using System.Web.Security;

namespace PlayEv.WebUI.Infrastructure.Concrete
{
    public class SimpleAuthProvider:IAuthProvider
    {
        public bool Authenticate(string username, string password, User user)
        {
            if (user == null)
            {
                return false;
            }

            bool valid = user.password == password;
            if(valid){
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return valid;
        }
    }
}