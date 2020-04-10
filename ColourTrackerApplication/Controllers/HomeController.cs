using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ColourTrackerDTOs;
using ColourTrackerRepositories;

namespace ColourTrackerApplication.Controllers
{
    public class HomeController : Controller
    {
        private IList<ColourModel> _colours;
        private readonly IStorageRepository _storageRepository;

        public HomeController(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
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
            var colourModels = _storageRepository.GetAllColours();

            _colours = new List<ColourModel>();

            foreach (var colourModel in colourModels)
            {
                var colour = new ColourModel();
                {
                    colour.Id = colourModel.Id;
                    colour.Name = colourModel.Name;
                    colour.Brand = colourModel.Brand;
                    colour.Expiry = colourModel.Expiry;

                    _colours.Add(colour);
                }                
            }
            return Json(_colours);
        }

        [Route("colours/new")]
        [HttpPost]
        public ActionResult AddColour(ColourModel colour)
        {
            _colours = _storageRepository.GetAllColours();

            colour.Id = _colours.Count + 1;

            _storageRepository.AddNewColour(colour);

            return Content("A colour has been added");
        }
    }
}
