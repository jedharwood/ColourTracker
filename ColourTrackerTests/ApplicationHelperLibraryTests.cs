using System.Collections.Generic;
using ColourTrackerDTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColourTrackerHelperLibraries;

namespace ColourTrackerTests
{
    [TestClass]
    public class ApplicationHelperLibraryTests
    {
        [TestMethod]
        public void MapColourModelsToJsonTest()
        {
            //Arrange
            List<ColourModel> colourModels = new List<ColourModel>
            {
                new ColourModel{                  
                    Id = 1,
                    Name = "Red",
                    Brand = "Daler",
                    Expiry = "03/22",
                    SerialNumber = null,
                    DateDeleted = null
                },
                new ColourModel{
                    Id = 2,
                    Name = "Blue",
                    Brand = "Daler",
                    Expiry = "03/22",
                    SerialNumber = null,
                    DateDeleted = null
                },
                new ColourModel{
                    Id = 3,
                    Name = "Green",
                    Brand = "Daler",
                    Expiry = "03/22",
                    SerialNumber = null,
                    DateDeleted = null
                }
            };

            var library = new ApplicationHelperLibrary();

            var expected = 3;

            //Act
            var result = library.MapColourModelsToJson(colourModels);

            var actual = result.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
