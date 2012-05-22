using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayEv.Model.Abstract;
using PlayEv.Model.Concrete;
using PlayEv.Model.Entities;
using PlayEv.WebUI.Models;

namespace PlayEv.WebUI.Controllers
{
    public class GameController : Controller
    {
        private IGameRepository repository;

        public GameController()
        {
            repository = new EFGameRepository();
        }

        public string Games()
        {
            string result = "";
            foreach (var game in repository.Games)
            {
                result += "\n" + game.Name;
            }
            return result;
        }

        public ActionResult SubmitGame()
        {
            ViewBag.Category = repository.GetCategories();
            return View(new GameModel());
        }

        [HttpPost]
        public ActionResult SubmitGame(GameModel game, HttpPostedFileBase icon, HttpPostedFileBase sourceCode)
        {
            
            if (ModelState.IsValid)
            {
                if(icon != null && sourceCode != null)
                {
                byte[] _icon = new byte[icon.ContentLength];
                byte[] _sourceCode = new byte[sourceCode.ContentLength];

                repository.SubmitGame(new Game { Name = game.Name, Description = game.Description, Category = game.Category, Icon = _icon, SourceCode=_sourceCode });
                
                RedirectToAction("Games");
                }
            }
            

            return View();
        }

    }
}
