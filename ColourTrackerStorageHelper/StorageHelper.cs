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

        public ColourModel AddColourToStorage(ColourModel colour)
        {
            using (StreamReader r = new StreamReader("TempStorage.json"))
            {
                string json = r.ReadToEnd();
                List<ColourModel> colours = JsonConvert.DeserializeObject<List<ColourModel>>(json); //this code is repeated - will refactor out into separate method

                colours.Add(colour);

                using (StreamWriter file = File.CreateText("TempStorage.json"))  //currently overwriting file with blank data. Need to fix.
                {
                    JsonSerializer serializer = new JsonSerializer();

                    var serializedColours = JsonConvert.SerializeObject(colours);

                    //serializer.Serialize(file, colours);
                    serializer.Serialize(file, serializedColours); 
                }

                return (colour);
            }
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
