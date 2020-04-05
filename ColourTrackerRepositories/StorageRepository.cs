using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ColourTrackerDTOs;

namespace ColourTrackerRepositories
{
    public class StorageRepository : IStorageRepository
    {
        public StorageRepository()
        {
        }

        public ColourDTO AddNewColour(ColourDTO colour)
        {
            throw new NotImplementedException();
        }

        //public Task<List<ColourDTO>> GetAllColours(List<ColourDTO> colours)
        //{
        //    throw new NotImplementedException();
        //}
        public List<ColourDTO> GetAllColours()
        {
            throw new NotImplementedException();
        }
    }
}
