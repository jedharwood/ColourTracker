using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ColourTrackerDTOs;

namespace ColourTrackerRepositories
{
    public interface IStorageRepository
    {
        Task<List<ColourDTO>> GetAllColours(List<ColourDTO> colours);
        public ColourDTO AddNewColour(ColourDTO colour);
    }
}
