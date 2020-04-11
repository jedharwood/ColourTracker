using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerRepositories
{
    public interface IStorageRepository
    {
        List<ColourModel> GetAllColours();

        ColourModel AddNewColour(ColourModel colour);

        ColourModel SoftDeleteColour(ColourModel colour);
    }
}
