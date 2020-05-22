using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerHelperLibraries
{
    public interface IApplicationHelperLibrary
    {
        List<ColourModel> MapColourModelsToJsonAndNullCheckDateDeleted(List<ColourModel> colourModels);
    }
}
