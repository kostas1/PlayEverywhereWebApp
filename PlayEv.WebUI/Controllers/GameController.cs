using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayEv.Model.Abstract;
using PlayEv.Model.Concrete;

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

    }
}
