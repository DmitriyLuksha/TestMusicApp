using Microsoft.AspNetCore.Mvc;

namespace TestMusicAppServer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
