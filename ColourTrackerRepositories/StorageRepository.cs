using System;
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
            throw new NotImplementedException();
        }
    }
}
