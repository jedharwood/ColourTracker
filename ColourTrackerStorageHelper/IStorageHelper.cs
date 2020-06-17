using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerStorageHelper
{
    public interface IStorageHelper
    {
        ColourModel AddColourToStorage(ColourModel colour);

        List<ColourModel> GetColoursFromStorage();

        List<ColourFamilyModel> GetColourFamiliesFromStorage();

        List<BrandModel> GetBrandsFromStorage();

        ColourModel GetColourFromStorageById(int colourId);

        ColourModel SoftDeleteColourFromStorage(ColourModel colour);

        ColourModel UpdateColourInStorage(ColourModel colour);
    }
}
