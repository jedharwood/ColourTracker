using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerStorageHelper
{
    public interface IStorageHelper
    {
        ColourModel AddColourToStorage(ColourModel colour);

        List<ColourModel> GetColoursFromStorage();

        ColourModel SoftDeleteColourFromStorage(ColourModel colour);

        ColourModel UpdateColourInStorage(ColourModel colour);
    }
}
