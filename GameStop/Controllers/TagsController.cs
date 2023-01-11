using Microsoft.AspNetCore.Mvc;
using GameStop.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStop.Controllers
{
    public class TagsController : Controller
    {
        private readonly GameStopContext _db;

        public TagsController(GameStopContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Tags.ToList());
        }

        public ActionResult Details(int id)
        {
            Tag thisTag = _db.Tags
                .Include(tag => tag.JoinEntities)
                .ThenInclude(join => join.VideoGame)
                .FirstOrDefault(tag => tag.TagId == id);
            return View(thisTag);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            _db.Tags.Add(tag);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}