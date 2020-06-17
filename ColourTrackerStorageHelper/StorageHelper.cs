using System.Collections.Generic;
using System.IO;
using ColourTrackerDTOs;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ColourTrackerHelperLibraries;
using System;

namespace ColourTrackerStorageHelper
{
    public class StorageHelper : IStorageHelper 
    {
        private IConfiguration _configuration;
        private IStorageHelperHelperLibrary _storageHelperLibrary;
        public List<ColourModel> Colours { get; set; }
        private readonly ILogger<StorageHelper> _logger;
        public string _colourStoragePath; 

        public StorageHelper(IConfiguration configuration, ILogger<StorageHelper> logger, IStorageHelperHelperLibrary storageHelperLibrary)
        {
            _logger = logger;
            _configuration = configuration;
            _storageHelperLibrary = storageHelperLibrary;
            _colourStoragePath = _configuration["Storage:Colours"];

            using (StreamReader streamReader = new StreamReader(_colourStoragePath))
            {
                string jsonContent = streamReader.ReadToEnd();

                Colours = JsonConvert.DeserializeObject<List<ColourModel>>(jsonContent);
            }
        }

        public List<BrandModel> GetBrandsFromStorage()
        {
            _logger.LogInformation("Getting all brands from storage");

            using (StreamReader r = new StreamReader(_configuration["Storage:Brands"]))
            {
                string jsonContent = r.ReadToEnd();

                var brands = JsonConvert.DeserializeObject<List<BrandModel>>(jsonContent);

                return (brands);
            }
        }

        public List<ColourFamilyModel> GetColourFamiliesFromStorage()
        {
            _logger.LogInformation("Getting all colour families from storage");

            using (StreamReader r = new StreamReader(_configuration["Storage:ColourFamilies"]))
            {
                string jsonContent = r.ReadToEnd();

                var colourFamilies = JsonConvert.DeserializeObject<List<ColourFamilyModel>>(jsonContent);

                return (colourFamilies);
            }
        }

        public List<ColourModel> GetColoursFromStorage()
        {
            _logger.LogInformation("Getting all colours from storage");

            return (Colours);
        }

        public ColourModel GetColourFromStorageById(int colourId)
        {
            _logger.LogInformation($"Getting [Colour: {colourId}] from storage");

            var colourModel = _storageHelperLibrary.GetById(Colours, colourId);

            return (colourModel);
        }

        public ColourModel AddColourToStorage(ColourModel colour)
        {
            _logger.LogInformation($"Adding [Colour: {colour.BrandName}, {colour.ColourName}] to storage");

            Colours.Add(colour);

            _storageHelperLibrary.SaveChanges(Colours, _colourStoragePath);

            return (colour);
        }

        public ColourModel UpdateColourInStorage(ColourModel colour)
        { 
            _storageHelperLibrary.MapUpdatedColourModel(Colours, colour);

            _logger.LogInformation($"Updating record for [Colour: {colour.Id}]");

            _storageHelperLibrary.SaveChanges(Colours, _colourStoragePath);

            return (colour);
        }

        public ColourModel SoftDeleteColourFromStorage(ColourModel colour)
        {
            var colourModel = _storageHelperLibrary.GetById(Colours, colour.Id);

            colourModel.DateDeleted = DateTime.Now;

            _logger.LogInformation($"Soft Deleting [Colour: {colour.Id}] from storage");

            _storageHelperLibrary.SaveChanges(Colours, _colourStoragePath);

            return (colour);
        }
    }
}
