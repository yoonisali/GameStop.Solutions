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


        public ActionResult AddVideoGame(int id)
        {
            Tag thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
            ViewBag.VideoGameId = new SelectList(_db.VideoGames, "VideoGameId", "Name");
            return View(thisTag);
        }

        [HttpPost]
        public ActionResult AddVideoGame(Tag tag, int videoGameId)
        {
#nullable enable
            VideoGameTag? joinEntity = _db.VideoGameTags.FirstOrDefault(join => (join.VideoGameId == videoGameId && join.TagId == tag.TagId));
#nullable disable
            if (joinEntity == null && videoGameId != 0)
            {
                _db.VideoGameTags.Add(new VideoGameTag() { VideoGameId = videoGameId, TagId = tag.TagId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = tag.TagId });
        }
    }
}