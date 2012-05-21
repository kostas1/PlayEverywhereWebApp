using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayEv.Model.Abstract;
using PlayEv.Model.Concrete;

namespace PlayEv.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository;

        public UserController()
        {
            repository = new EFUserRepository();
        }

        public string Users()
        {
            string result = "";
            foreach(var user in repository.Users){
                result += user.Nickname;
            }
            return result;
        }

    }
}
