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

                return (colours);
            }
        }
    }
}
