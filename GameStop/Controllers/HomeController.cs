using Microsoft.AspNetCore.Mvc;
using GameStop.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace GameStop.Controllers
{
    public class HomeController : Controller
    {
      private readonly GameStopContext _db;
      private readonly UserManager<ApplicationUser> _userManager;

      public HomeController(UserManager<ApplicationUser> userManager, GameStopContext db)
      {
        _userManager = userManager;
        _db = db;
      }

      [HttpGet("/")]
      public async Task<ActionResult> Index()
      {
        Gamer[] gamers = _db.Gamers.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string, object[]>();
        model.Add("gamers", gamers);
        string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        if (currentUser != null)
        {
          VideoGame[] videogames = _db.VideoGames
                      .Where(entry => entry.User.Id == currentUser.Id)
                      .ToArray();
          model.Add("videogames", videogames);
        }
        return View(model);
      }
    }
}