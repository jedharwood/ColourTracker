using System.Collections.Generic;
using System.IO;
using ColourTrackerDTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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

                JArray colourJsonArray = new JArray();

                foreach (ColourModel col in colours)
                {
                    JObject colourJson = new JObject(
                        new JProperty("id", col.Id),
                        new JProperty("name", col.Name),
                        new JProperty("brand", col.Brand),
                        new JProperty("expiry", col.Expiry)
                        );

                    colourJsonArray.Add(colourJson);
                }

                JObject colourJsonNew = new JObject(
                    new JProperty("id", colour.Id),
                    new JProperty("name", colour.Name),
                    new JProperty("brand", colour.Brand),
                    new JProperty("expiry", colour.Expiry)
                );

                colourJsonArray.Add(colourJsonNew);

                using (StreamWriter file = File.CreateText("TempStorage.json"))

                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    colourJsonArray.WriteTo(writer);
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
