using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerStorageHelper
{
    public interface IStorageHelper
    {
        List<ColourModel> GetColoursFromStorage();

        ColourModel AddColourToStorage();
    }
}
