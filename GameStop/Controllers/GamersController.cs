using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GameStop.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameStop.Controllers
{
    public class GamersController : Controller
    {
        private readonly GameStopContext _db;

        public GamersController(GameStopContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Gamer> model = _db.Gamers.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Gamer gamer)
        {
            _db.Gamers.Add(gamer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            Gamer thisGamer = _db.Gamers
                                      .Include(cat => cat.VideoGames)
                                      .ThenInclude(videoGame => videoGame.JoinEntities)
                                      .ThenInclude(join => join.Tag)
                                      .FirstOrDefault(gamer => gamer.GamerId == id);
            return View(thisGamer);
        }
    }
}
