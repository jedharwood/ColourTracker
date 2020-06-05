using System.Collections.Generic;
using ColourTrackerDTOs;
using ColourTrackerStorageHelper;
using Microsoft.Extensions.Logging;

namespace ColourTrackerRepositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly IStorageHelper _storageHelper;
        private readonly ILogger<StorageRepository> _logger;

        public StorageRepository(IStorageHelper storageHelper, ILogger<StorageRepository> logger)
        {
            _logger = logger;

            _storageHelper = storageHelper;
        }

        public List<ColourModel> GetAllColours()
        {
            _logger.LogInformation("Getting all colours from storage via StorageHelper");

            var colours = _storageHelper.GetColoursFromStorage();

            return (colours);
        }

        public List<ColourFamilyModel> GetAllColourFamilies()
        {
            _logger.LogInformation("Getting all colour families from storage via StorageHelper");

            var colourFamilies = _storageHelper.GetColourFamiliesFromStorage();

            return (colourFamilies);
        }

        public List<BrandModel> GetAllBrands()
        {
            _logger.LogInformation("Getting all brands from storage via StorageHelper");

            var brands = _storageHelper.GetBrandsFromStorage();

            return (brands);
        }

        public ColourModel GetColourById(int colourId)
        {
            _logger.LogInformation($"Getting [Colour: {colourId}] from storage via Storage Helper");

            var colourModel = _storageHelper.GetColourFromStorageById(colourId);

            return (colourModel);
        }

        public ColourModel AddNewColour(ColourModel colour)
        {
            _logger.LogInformation($"Adding [Colour: {colour.BrandName}, {colour.ColourName}] to storage via StorageHelper");

            _storageHelper.AddColourToStorage(colour);

            return (colour);
        }

        public ColourModel SoftDeleteColour(ColourModel colour)
        {
            _logger.LogInformation($"SoftDeleting [Colour: {colour.Id}] from storage via StorageHelper");

            _storageHelper.SoftDeleteColourFromStorage(colour);

            return (colour);
        }

        public ColourModel UpdateColour(ColourModel colour)
        {
            _logger.LogInformation($"Updating record for [Colour: {colour.Id}] via StorageHelper");

            _storageHelper.UpdateColourInStorage(colour);

            return (colour);
        }
    }
}
