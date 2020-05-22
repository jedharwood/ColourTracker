using System;
using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerHelperLibraries
{
    public class ApplicationHelperLibrary : IApplicationHelperLibrary
    {
        public List<ColourModel> MapColourModelsToJson(List<ColourModel> colourModels)
        {
            var list = new List<ColourModel>();

            foreach (var colourModel in colourModels)
            {
                var colour = new ColourModel();
                {
                    colour.Id = colourModel.Id;
                    colour.Name = colourModel.Name;
                    colour.Brand = colourModel.Brand;
                    colour.Expiry = colourModel.Expiry;
                    colour.SerialNumber = colourModel.SerialNumber;
                    colour.DateAdded = colourModel.DateAdded;
                    colour.DateDeleted = colourModel.DateDeleted;

                    if (colour.DateDeleted == null) //Would like to handle this conditional rendering with the react component
                    {
                        list.Add(colour);
                    }
                }
            }

            return list;
        }
    }
}
