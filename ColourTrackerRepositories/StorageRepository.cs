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

        public List<ColourModel> GetAllColours()
        {
            var colours = new List<ColourModel>
            {
                new ColourModel
                    {
                        Id = 1,
                        Name = "Red",
                        Brand = "Waverly",
                        Expiry = "03/22"
                    },
                    new ColourModel
                    {
                        Id = 2,
                        Name = "Golden Yellow",
                        Brand = "Old Gold",
                        Expiry = "05/24"
                    },
                    new ColourModel
                    {
                        Id = 3,
                        Name = "Olive",
                        Brand = "DermaGlo",
                        Expiry = "02/22"
                    }
            };

            return (colours);

            //throw new NotImplementedException();
        }

        public ColourModel AddNewColour(ColourModel colour)
        {
            throw new NotImplementedException();
        }
    }
}
