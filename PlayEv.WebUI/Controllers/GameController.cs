using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayEv.Model.Abstract;
using PlayEv.Model.Concrete;
using PlayEv.Model.Entities;
using System.Text;

namespace PlayEv.WebUI.Controllers
{
    public class GameController : Controller
    {
        private IGameRepository repository;

        public GameController()
        {
            repository = new EFGameRepository();
        }

        public ActionResult List()
        {
            return View(repository.Games);
        }

        public ActionResult Play(int gameId)
        {
            Game game = repository.Games.FirstOrDefault(g => g.Id == gameId);
            
            if(game !=null && game.SourceCode != null){
                StringBuilder sourceCode = new StringBuilder();
                foreach (byte s in game.SourceCode)
                {
                    sourceCode.Append(s);
                }
                ViewBag.Code = sourceCode.ToString();
            }
            
            return View();
        }

    }
}
