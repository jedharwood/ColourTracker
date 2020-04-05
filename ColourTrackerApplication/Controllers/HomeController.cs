using Microsoft.AspNetCore.Mvc;
using ColourTrackerApplication.Models;
using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerApplication.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<ColourModel> _colours;

        static HomeController()
        {
            _colours = new List<ColourModel>
            {
                new ColourModel
                {
                    Id = 1,
                    Name = "Red",
                    Brand = "Waverly",
                    Expiry = "03/22"
                },
                new ColourModel
                {
                    Id = 2,
                    Name = "Golden Yellow",
                    Brand = "Old Gold",
                    Expiry = "05/24"
                },
                new ColourModel
                {
                    Id = 3,
                    Name = "Olive",
                    Brand = "DermaGlo",
                    Expiry = "02/22"
                },
            };
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Route("colours")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult GetAllColours()
        {
            return Json(_colours);
        }

        [Route("colours/new")]
        [HttpPost]
        public ActionResult AddColour(ColourModel colour)
        {
            colour.Id = _colours.Count + 1;
            _colours.Add(colour);
            return Content("A colour has been added");
        }
    }
}
