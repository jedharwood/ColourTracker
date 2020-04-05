using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ColourTrackerDTOs;

namespace ColourTrackerRepositories
{
    public interface IStorageRepository
    {
        List<ColourModel> GetAllColours();
        ColourModel AddNewColour(ColourModel colour);
    }
}
