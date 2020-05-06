using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ColourTrackerDTOs;
using ColourTrackerRepositories;
using System;
using Microsoft.Extensions.Logging;

namespace ColourTrackerApplication.Controllers
{
    public class HomeController : Controller
    {
        private IList<ColourModel> _colours;
        private readonly IStorageRepository _storageRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IStorageRepository storageRepository, ILogger<HomeController> logger)
        {
            _storageRepository = storageRepository;
            _logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            _logger.LogInformation("Loading Home/Index");

            return View();
        }

        [Route("colours")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult GetAllColours()
        {
            _logger.LogInformation("Getting all colours from storage via StorageRepository");

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

            _logger.LogInformation($"Adding [Colour: {colour.Brand}, {colour.Name}] to storage via StorageRepository");

            _storageRepository.AddNewColour(colour);

            return Content("Your colour has been added");
        }

        [Route("colours/softDelete/{colour.Id}")]
        [HttpPost]
        public ActionResult SoftDeleteColour(ColourModel colour)
        {
            colour.DateDeleted = DateTime.Now;

            _logger.LogInformation($"Soft Deleting [Colour: {colour.Id}] from storage via StorageRepository");

            _storageRepository.SoftDeleteColour(colour);

            return Content("Your colour has been deleted");
        }

        [Route("colours/populateEditForm")]
        [HttpPost]
        public ActionResult Edit([FromForm] ColourModel colour)
        {
            _logger.LogInformation($"Receiving parameters for [Colour: {colour.Id}] from view to populate Edit Form");

            return View("Edit", colour);
        }

        [Route("colours/submitEdit")]
        [HttpPost]
        public ActionResult UpdateColour(ColourModel colour)
        {
            colour.DateModified = DateTime.Now;

            _logger.LogInformation($"Updating record for [Colour: {colour.Id}] via StorageRepository");

            _storageRepository.UpdateColour(colour);

            return Content("Your colour has been updated");
        }
    }
}
