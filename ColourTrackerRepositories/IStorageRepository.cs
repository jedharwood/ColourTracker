using System.Collections.Generic;
using ColourTrackerDTOs;

namespace ColourTrackerRepositories
{
    public interface IStorageRepository
    {
        List<ColourModel> GetAllColours();

        List<ColourFamilyModel> GetAllColourFamilies();

        List<BrandModel> GetAllBrands();

        ColourModel GetColourById(int colourId);

        ColourModel AddNewColour(ColourModel colour);

        ColourModel SoftDeleteColour(ColourModel colour);

        ColourModel UpdateColour(ColourModel colour);
    }
}
