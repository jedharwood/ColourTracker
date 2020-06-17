using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerHelperLibraries
{
    public interface IStorageHelperHelperLibrary
    {
        ColourModel GetById(List<ColourModel> colours, int colourId);

        List<ColourModel> MapUpdatedColourModel(List<ColourModel> colours, ColourModel colour);

        void SaveChanges(List<ColourModel> colours, string colourStoragePath);
    }
}
