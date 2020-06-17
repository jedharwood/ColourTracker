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

        [Route("colourfamilies")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult GetAllColourFamilies()
        {
            _logger.LogInformation("Getting all colour families from storage via StorageRepository");

            var colourFamilies = _storageRepository.GetAllColourFamilies();

            return Json(colourFamilies);
        }

        [Route("brands")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult GetAllBrands()
        {
            _logger.LogInformation("Getting all brands from storage via StorageRepository");

            var brands = _storageRepository.GetAllBrands();

            return Json(brands);
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

        [Route("colours/{colour.Id}")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult GetColourById(ColourModel colour)
        {
            _logger.LogInformation($"Getting [Colour: {colour.Id}] by from storage via StorageRepository");

            var colours = _storageRepository.GetColourById(colour.Id);

            return Json(colours);
        }

        [Route("colours/new")]
        [HttpPost]
        public ActionResult AddColour([FromBody]ColourModel colour)
        {
            _colours = _storageRepository.GetAllColours();

            colour.Id = _colours.Count + 1;  //null reference exception

            colour.DateAdded = DateTime.Now;  //move to helper

            colour.DateDeleted = null;

            _logger.LogInformation($"Adding [Colour: {colour.BrandName}, {colour.ColourName}] to storage via StorageRepository");

            _storageRepository.AddNewColour(colour);

            return Content("Your colour has been added");  //return status?
        }

        [Route("colours/softDelete/{colour.Id}")]
        [HttpPost]
        public ActionResult SoftDeleteColour(ColourModel colour)
        {
            _logger.LogInformation($"Soft Deleting [Colour: {colour.Id}] from storage via StorageRepository");

            _storageRepository.SoftDeleteColour(colour);

            return Content("Your colour has been deleted");
        }

        [Route("colours/submitEdit")]
        [HttpPost]
        public ActionResult UpdateColour(ColourModel colour)
        {
            colour.DateModified = DateTime.Now;  //move to helper

            _logger.LogInformation($"Updating record for [Colour: {colour.Id}] via StorageRepository");

            _storageRepository.UpdateColour(colour);

            return Content("Your colour has been updated");
        }
    }
}
