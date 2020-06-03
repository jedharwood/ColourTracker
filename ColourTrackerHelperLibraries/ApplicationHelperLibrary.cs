using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerHelperLibraries
{
    public class ApplicationHelperLibrary : IApplicationHelperLibrary
    {
        public List<ColourModel> MapColourModelsToJsonAndNullCheckDateDeleted(List<ColourModel> colourModels)
        {
            var list = new List<ColourModel>();

            foreach (var colourModel in colourModels)
            {
                var colour = new ColourModel();
                {
                    colour.Id = colourModel.Id;
                    colour.ColourName = colourModel.ColourName;
                    colour.ColourFamily = colourModel.ColourFamily;
                    colour.ColourFamilyId = colourModel.ColourFamilyId;
                    colour.BrandName = colourModel.BrandName;
                    colour.BrandId = colourModel.BrandId;
                    colour.Expiry = colourModel.Expiry;
                    colour.SerialNumber = colourModel.SerialNumber;
                    colour.DateAdded = colourModel.DateAdded;
                    colour.DateDeleted = colourModel.DateDeleted;
                    colour.DateModified = colourModel.DateModified;

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
