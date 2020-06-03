using System.Collections.Generic;
using ColourTrackerDTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColourTrackerHelperLibraries;
using System;
using System.Linq;

namespace ColourTrackerTests
{
    [TestClass]
    public class ApplicationHelperLibraryTests
    {
        public List<ColourModel> Colours { get; set; }
        public ApplicationHelperLibrary Library;

        public ApplicationHelperLibraryTests()
        {
            Library = new ApplicationHelperLibrary();

            Colours = new List<ColourModel>
            {
                new ColourModel{
                    Id = 1,
                    ColourName = "Red",
                    ColourFamily = 4,
                    Brand = "Waverly",
                    BrandId = 1,
                    Expiry = "03/22",
                    SerialNumber = null,
                    DateDeleted = DateTime.Parse("0001-01-01T00:00:00"),
                    DateModified = null,
                    DateAdded = DateTime.Parse("0001-01-01T00:00:00")

                },
                new ColourModel{
                    Id = 2,
                    ColourName = "Blue",
                    ColourFamily = 9,
                    Brand = "Old Gold",
                    BrandId = 2,
                    Expiry = "03/22",
                    SerialNumber = null,
                    DateDeleted = null,
                    DateModified = null,
                    DateAdded = DateTime.Parse("0001-01-01T00:00:00")
                },
                new ColourModel{
                    Id = 3,
                    ColourName = "Green",
                    ColourFamily = 7,
                    Brand = "Solid Colour",
                    BrandId = 3,
                    Expiry = "03/22",
                    SerialNumber = null,
                    DateDeleted = null,
                    DateModified = null,
                    DateAdded = DateTime.Parse("0001-01-01T00:00:00")
                }
            };
        }

        [TestMethod]
        public void MapColourModelsToJsonTest()
        {
            //Arrange
            var expected = Colours.Count - 1;

            //Act
            var actual = Library.MapColourModelsToJsonAndNullCheckDateDeleted(Colours).Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckForInvalidColourNames()
        {
            //Arrange
            List<ColourModel> invalidNamedColours = new List<ColourModel> { };

            var expected = 0;

            //Act
            foreach (var colour in Colours)
            {
                if (colour.ColourName == null || colour.ColourName.GetType() != typeof(string))
                {
                    invalidNamedColours.Add(colour);
                }
            }

            var actual = invalidNamedColours.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VerifyThatIdNumbersAreUnique()
        {
            //Arrange
            List<int> idNumbers = new List<int> { };

            var expected = Colours.Count;

            //Act
            foreach (var colour in Colours)
            {
                idNumbers.Add(colour.Id);
            }

            var actual = idNumbers.Distinct().Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
