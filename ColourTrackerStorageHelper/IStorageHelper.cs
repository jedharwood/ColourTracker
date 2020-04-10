﻿using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerStorageHelper
{
    public interface IStorageHelper
    {
        ColourModel AddColourToStorage(ColourModel colour);

        List<ColourModel> GetColoursFromStorage();
    }
}
