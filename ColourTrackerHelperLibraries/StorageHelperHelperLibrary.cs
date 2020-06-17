using System.Collections.Generic;
using System.IO;
using ColourTrackerDTOs;
using Newtonsoft.Json;

namespace ColourTrackerHelperLibraries
{
    public class StorageHelperHelperLibrary : IStorageHelperHelperLibrary
    {
        public ColourModel GetById(List<ColourModel> colours, int colourId)
        {
            var colourModel = new ColourModel();

            for (var i = 0; i < colours.Count; i++)
            {
                if (colours[i].Id == colourId)
                {
                    colourModel = colours[i];

                    break;
                }
            }

            return (colourModel);
        }

        public List<ColourModel> MapUpdatedColourModel(List<ColourModel> colours, ColourModel colour)
        {
            var existingRecord = GetById(colours, colour.Id);

            existingRecord.ColourName = colour.ColourName;
            existingRecord.ColourFamily = colour.ColourFamily;
            existingRecord.ColourFamilyId = colour.ColourFamilyId;
            existingRecord.BrandName = colour.BrandName;
            existingRecord.BrandId = colour.BrandId;
            existingRecord.Expiry = colour.Expiry;
            existingRecord.SerialNumber = colour.SerialNumber;
            existingRecord.DateModified = colour.DateModified;  //move the dade modified out here from the controller. same fopr date deleted, etc...

            return (colours);
        }

        public void SaveChanges(List<ColourModel> colours, string colourStoragePath)
        {
            using (StreamWriter file = File.CreateText(colourStoragePath))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();

                jsonSerializer.Serialize(file, colours);
            } 
        }
    }
}
