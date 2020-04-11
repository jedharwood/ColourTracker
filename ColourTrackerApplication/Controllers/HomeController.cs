using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ColourTrackerDTOs;
using ColourTrackerRepositories;
using System;

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
                    colour.SerialNumber = colourModel.SerialNumber;
                    colour.DateAdded = colourModel.DateAdded;
                    colour.DateDeleted = colourModel.DateDeleted;
                    
                    if (colour.DateDeleted == null) //Would like to handle this conditional rendering with the react component
                    {
                        _colours.Add(colour);
                    }                 
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

            colour.DateAdded = DateTime.Now;

            colour.DateDeleted = null;

            _storageRepository.AddNewColour(colour);

            return Content("Your colour has been added");
        }

        [Route("colours/softDelete")]
        [HttpPost]
        public ActionResult SoftDeleteColour(ColourModel colour)
        {
            colour.DateDeleted = DateTime.Now;

            _storageRepository.SoftDeleteColour(colour);

            return Content("Your colour has been deleted");
        }
    }
}
