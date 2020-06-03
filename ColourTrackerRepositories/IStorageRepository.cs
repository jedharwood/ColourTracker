using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerRepositories
{
    public interface IStorageRepository
    {
        List<ColourModel> GetAllColours();

        List<ColourFamily> GetAllColourFamilies();

        List<ColourBrand> GetAllBrands();

        ColourModel AddNewColour(ColourModel colour);

        ColourModel SoftDeleteColour(ColourModel colour);

        ColourModel UpdateColour(ColourModel colour);
    }
}
