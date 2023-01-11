using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GameStop.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace GameStop.Controllers
{
    [Authorize]
    public class VideoGamesController : Controller
    {
        private readonly GameStopContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public VideoGamesController(UserManager<ApplicationUser> userManager, GameStopContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            List<VideoGame> userVideoGames = _db.VideoGames
                                .Where(entry => entry.User.Id == currentUser.Id)
                                .Include(videogame => videogame.Gamer)
                                .ToList();
            return View(userVideoGames);
        }
    }
}