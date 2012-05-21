using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayEv.Model.Abstract;
using PlayEv.Model.Concrete;
using PlayEv.WebUI.Models;
using PlayEv.WebUI.Infrastructure.Abstract;
using System.Text;
using System.Security.Cryptography;
using System.Web.Security;

namespace PlayEv.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository;
        private IAuthProvider authProvider;
        private MD5 md5;

        public UserController(IUserRepository repository, IAuthProvider authProvider)
        {
            this.repository = repository;
            this.authProvider = authProvider;
            this.md5 = new MD5CryptoServiceProvider();
        }

        public string List()
        {
            string result = "";
            foreach (var user in repository.Users)
            {
                result += user.Nickname;
            }
            return result;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                string encoded = CalculateMD5(user.Password);
                if (authProvider.Authenticate(user.Email, encoded, repository.Users.FirstOrDefault(u => u.Email == user.Email)))
                {
                    return RedirectToAction("Account");
                }
                else
                {
                    TempData["message"] = "Login failed";
                }
            }

            return View();
        }

        public ActionResult Account()
        {
            return null;
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        private string CalculateMD5(string password)
        {
            byte[] b = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sB = new StringBuilder();
            foreach (var a in b)
            {
                sB.Append(a);
            }
            return sB.ToString();
        }

    }
}
