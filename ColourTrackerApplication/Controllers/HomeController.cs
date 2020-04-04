using Microsoft.AspNetCore.Mvc;

namespace ColourTrackerApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
