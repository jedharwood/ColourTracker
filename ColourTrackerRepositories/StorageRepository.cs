using System.Collections.Generic;
using ColourTrackerDTOs;
using ColourTrackerStorageHelper;

namespace ColourTrackerRepositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly IStorageHelper _storageHelper;

        public StorageRepository(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
        }

        public List<ColourModel> GetAllColours()
        {
            var colours = _storageHelper.GetColoursFromStorage();

            return (colours);
        }

        public ColourModel AddNewColour(ColourModel colour)
        {
            _storageHelper.AddColourToStorage(colour);

            return (colour);
        }

        public ColourModel SoftDeleteColour(ColourModel colour)
        {
            _storageHelper.SoftDeleteColourFromStorage(colour);

            return (colour);
        }

        public ColourModel UpdateColour(ColourModel colour)
        {
            _storageHelper.UpdateColourInStorage(colour);

            return (colour);
        }
    }
}
