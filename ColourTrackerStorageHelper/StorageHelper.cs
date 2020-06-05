using System.Collections.Generic;
using System.IO;
using ColourTrackerDTOs;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace ColourTrackerStorageHelper
{
    public class StorageHelper : IStorageHelper 
    {
        private IConfiguration _configuration;
        public List<ColourModel> Colours { get; set; }
        private readonly ILogger<StorageHelper> _logger;

        public StorageHelper(IConfiguration configuration, ILogger<StorageHelper> logger)
        {
            _logger = logger;
            _configuration = configuration;

            using (StreamReader streamReader = new StreamReader(_configuration["Storage:Colours"]))
            {
                string jsonContent = streamReader.ReadToEnd();

                Colours = JsonConvert.DeserializeObject<List<ColourModel>>(jsonContent);
            }
        }

        public ColourModel AddColourToStorage(ColourModel colour)
        {
            _logger.LogInformation($"Adding [Colour: {colour.BrandName}, {colour.ColourName}] to storage");

            Colours.Add(colour);

            SaveChanges();

            return (colour);
        }

        public List<ColourModel> GetColoursFromStorage()
        {
            _logger.LogInformation("Getting all colours from storage");

            using (StreamReader r = new StreamReader(_configuration["Storage:Colours"]))
            {
                return (Colours);
            }
        }

        public ColourModel GetColourFromStorageById(int colourId)
        {
            _logger.LogInformation($"Getting [Colour: {colourId}] from storage");

            var colourModel = GetById(colourId);

            return (colourModel);
        }

        public List<ColourFamilyModel> GetColourFamiliesFromStorage()
        {
            _logger.LogInformation("Getting all colour families from storage");

            using (StreamReader r = new StreamReader(_configuration["Storage:ColourFamilies"]))
            {
                string jsonContent = r.ReadToEnd();

                var colourFamilies= JsonConvert.DeserializeObject<List<ColourFamilyModel>>(jsonContent);

                return (colourFamilies);
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

        public ColourModel SoftDeleteColourFromStorage(ColourModel colour)
        {
            foreach (var colourModel in Colours)
            {
                if (colourModel.Id == colour.Id)
                {
                    _logger.LogInformation($"Soft Deleting [Colour: {colour.Id}] from storage");

                    colourModel.DateDeleted = colour.DateDeleted;
                }               
            }

            SaveChanges();

            return (colour);
        }

        public ColourModel UpdateColourInStorage(ColourModel colour)
        {
            foreach (var colourModel in Colours)
            {
                if (colourModel.Id == colour.Id)
                {
                    _logger.LogInformation($"Updating record for [Colour: {colour.Id}]");

                    colourModel.ColourName = colour.ColourName;
                    colourModel.ColourFamily = colour.ColourFamily;
                    colourModel.ColourFamilyId = colour.ColourFamilyId;
                    colourModel.BrandName = colour.BrandName;
                    colourModel.BrandId = colour.BrandId;
                    colourModel.Expiry = colour.Expiry;
                    colourModel.SerialNumber = colour.SerialNumber;
                    colourModel.DateModified = colour.DateModified;
                }
            }

            SaveChanges();

            return (colour);
        }

        public void SaveChanges()
        {
            using (StreamWriter file = File.CreateText(_configuration["Storage:Colours"]))
            {
                _logger.LogInformation("Saving changes");

                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(file, Colours);
            }
        }

        private ColourModel GetById(int colourId)
        {
            var colourModel = new ColourModel();

            for (var i = 0; i < Colours.Count; i++)
            {
                if (Colours[i].Id == colourId)
                {
                    colourModel = Colours[i];

                    break;
                }
            }

            return (colourModel);
        }
    }
}
