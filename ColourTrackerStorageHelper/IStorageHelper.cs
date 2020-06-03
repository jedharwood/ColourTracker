using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerStorageHelper
{
    public interface IStorageHelper
    {
        ColourModel AddColourToStorage(ColourModel colour);

        List<ColourModel> GetColoursFromStorage();

        List<ColourFamily> GetColourFamiliesFromStorage();

        List<ColourBrand> GetBrandsFromStorage();

        ColourModel SoftDeleteColourFromStorage(ColourModel colour);

        ColourModel UpdateColourInStorage(ColourModel colour);
    }
}
