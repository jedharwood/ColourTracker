using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ColourTrackerDTOs;
using ColourTrackerRepositories;
using System;
using Microsoft.Extensions.Logging;
using ColourTrackerHelperLibraries;

namespace ColourTrackerApplication.Controllers
{
    public class HomeController : Controller
    {
        private IList<ColourModel> _colours;
        private readonly IStorageRepository _storageRepository;
        private readonly IApplicationHelperLibrary _applicationHelperLibrary;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IStorageRepository storageRepository, ILogger<HomeController> logger, IApplicationHelperLibrary applicationHelperLibrary)
        {
            _storageRepository = storageRepository;
            _logger = logger;
            _applicationHelperLibrary = applicationHelperLibrary;
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

            _colours = _applicationHelperLibrary.MapColourModelsToJsonAndNullCheckDateDeleted(colourModels);

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

            _logger.LogInformation($"Adding [Colour: {colour.BrandName}, {colour.ColourName}] to storage via StorageRepository");

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

        //[Route("colours/populateEditForm")]
        //[HttpPost]
        //public ActionResult Edit([FromForm] ColourModel colour)
        //{
        //    _logger.LogInformation($"Receiving parameters for [Colour: {colour.Id}] from view to populate Edit Form");

        //    return View("Edit", colour);
        //}

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
