using System.Collections.Generic;
using ColourTrackerDTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColourTrackerHelperLibraries;
using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

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

            string path = AppDomain.CurrentDomain.BaseDirectory + "Data/TestingMockColourData.json";

            using (StreamReader streamReader = new StreamReader(path))
            {
                string jsonContent = streamReader.ReadToEnd();

                Colours = JsonConvert.DeserializeObject<List<ColourModel>>(jsonContent);
            }
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
