﻿using System.Collections.Generic;
using System.IO;
using ColourTrackerDTOs;
using Newtonsoft.Json;

namespace ColourTrackerStorageHelper
{
    public class StorageHelper : IStorageHelper
    {
        public List<ColourModel> Colours { get; set; }

        public StorageHelper()
        {
            using (StreamReader streamReader = new StreamReader("TempStorage.json"))
            {
                string jsonContent = streamReader.ReadToEnd();
                Colours = JsonConvert.DeserializeObject<List<ColourModel>>(jsonContent);
            }
        }

        public ColourModel AddColourToStorage(ColourModel colour)
        {
            Colours.Add(colour);

            SaveChanges();

            return (colour);
        }

        public List<ColourModel> GetColoursFromStorage()
        {
            using (StreamReader r = new StreamReader("TempStorage.json"))
            {
                return (Colours);
            }
        }

        public ColourModel SoftDeleteColourFromStorage(ColourModel colour)
        {
            foreach (var colourModel in Colours)
            {
                if (colourModel.Id == colour.Id)
                {
                    colourModel.DateDeleted = colour.DateDeleted;
                }               
            }

            SaveChanges();

            return (colour);
        }

        public void SaveChanges()
        {
            using (StreamWriter file = File.CreateText("TempStorage.json"))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(file, Colours);
            }
        }
    }
}
