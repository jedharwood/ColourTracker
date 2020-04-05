using System;
using System.Collections.Generic;
using System.IO;
using ColourTrackerDTOs;
using Newtonsoft.Json;


namespace ColourTrackerStorageHelper
{
    public class StorageHelper : IStorageHelper
    {
        public StorageHelper()
        {
        }

        public ColourModel AddColourToStorage()
        {
            throw new NotImplementedException();
        }

        public List<ColourModel> GetColoursFromStorage()
        {
            using (StreamReader r = new StreamReader("TempStorage.json"))
            {
                string json = r.ReadToEnd();
                List<ColourModel> colours = JsonConvert.DeserializeObject<List<ColourModel>>(json);

                return (colours); //reading colours from json file - now need to pass colour list out into main method to be returned
            }
            //var colours = new List<ColourModel>
            //{
            //    new ColourModel
            //    {
            //        Id = 1,
            //        Name = "Red",
            //        Brand = "Waverly",
            //        Expiry = "03/22"
            //    },
            //    new ColourModel
            //    {
            //        Id = 2,
            //        Name = "Golden Yellow",
            //        Brand = "Old Gold",
            //        Expiry = "05/24"
            //    },
            //    new ColourModel
            //    {
            //        Id = 3,
            //        Name = "Olive",
            //        Brand = "DermaGlo",
            //        Expiry = "02/22"
            //    }
            //};
            //return (colours);
        }
    }
}
