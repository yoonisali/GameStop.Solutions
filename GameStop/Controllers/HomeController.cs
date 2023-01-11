using Microsoft.AspNetCore.Mvc;

namespace GameStop.Controllers 
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}