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
using System.Web.UI;
using PlayEv.Model.Entities;

namespace PlayEv.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository;
        private IAuthProvider authProvider;
        private ISecurePass passEncrypter;

        public UserController(IUserRepository repository, IAuthProvider authProvider, ISecurePass passEncrypter)
        {
            this.repository = repository;
            this.authProvider = authProvider;
            this.passEncrypter = passEncrypter;
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
                string encoded = passEncrypter.encriptPassword(user.Password);
                if (authProvider.Authenticate(user.Username, encoded, repository.Users.FirstOrDefault(u => u.Username == user.Username)))
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

        [Authorize]
        public ActionResult Account()
        {
            var user = repository.Users.FirstOrDefault(u => u.Username == User.Identity.Name);
            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View(new UserLoginViewModel());
        }

        [HttpPost]
        public ActionResult Register(UserLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var existing = repository.Users.FirstOrDefault(u => u.Username == user.Username);
                if (existing == null)
                {
                    repository.CreateUser(new User { Username = user.Username, Password = passEncrypter.encriptPassword(user.Password) });
                    return RedirectToAction("Account");
                }
                else
                {
                    ModelState.AddModelError("Error","Username already takken");
                }
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddFriend(string username)
        {

            return View();
        }
    }
}
