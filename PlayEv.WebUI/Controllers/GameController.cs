using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayEv.Model.Abstract;
using PlayEv.Model.Concrete;
using PlayEv.Model.Entities;
using PlayEv.WebUI.Models;
using System.Text;
using System.IO;

namespace PlayEv.WebUI.Controllers
{
    public class GameController : Controller
    {
        private IGameRepository repository;

        public GameController()
        {
            repository = new EFGameRepository();
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
                if (icon != null && sourceCode != null)
                {
                    byte[] _icon = new byte[icon.ContentLength];
                    byte[] _sourceCode = new byte[sourceCode.ContentLength];
                    icon.InputStream.Read(_icon, 0, icon.ContentLength);
                    sourceCode.InputStream.Read(_sourceCode, 0, sourceCode.ContentLength);
                    repository.SubmitGame(new Game { Name = game.Name, Description = game.Description, Category = game.Category, Icon = _icon, SourceCode = _sourceCode });


                    return RedirectToAction("List");
                }
            }


            return View(game);
        }

        public ActionResult List()
        {
            return View(repository.Games);
        }

        public ActionResult Play(int game)
        {
            ViewBag.GameId = game;
            return View();
        }

        public ActionResult GameWindow(int gameId, string session)
        {
            ViewBag.GameId = gameId;
            return View();
        }

        public FileContentResult GameCode(int gameId)
        {
            Game game = repository.Games.FirstOrDefault(g => g.Id == gameId);
            if (game != null)
            {
                if (game.SourceCode != null)
                {
                    return File(game.SourceCode, "text/javascript");
                }
            }
                return null;
        }
    }
}
