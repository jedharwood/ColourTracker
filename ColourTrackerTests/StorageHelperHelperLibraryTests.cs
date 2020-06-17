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
    public class StorageHelperHelperLibraryTests
    {
        public List<ColourModel> Colours { get; set; }
        public StorageHelperHelperLibrary Library;
        
        public StorageHelperHelperLibraryTests()
        {
            Library = new StorageHelperHelperLibrary();

            string path = AppDomain.CurrentDomain.BaseDirectory + "Data/TestingMockColourData.json";

            using (StreamReader streamReader = new StreamReader(path))
            {
                string jsonContent = streamReader.ReadToEnd();

                Colours = JsonConvert.DeserializeObject<List<ColourModel>>(jsonContent);
            }
        }

        [TestMethod]
        public void CheckThatResultIdMatchesRequest()
        {
            //Arrange
            var expected = 1;

            //Act
            var sut = Library.GetById(Colours, 1);

            var actual = sut.Id;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckThatSingleResultIsReturned()
        {
            //Arrange
            var expected = 1;

            //Act
            var sut = new List<ColourModel> { };

            sut.Add(Library.GetById(Colours, 1));

            var actual = sut.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckUpdatedValuesMapCorrectlyPositive()
        {
            //Arrange
            var expected = new ColourModel
            {
                Id = 2, 
                ColourName = "Blue",
                ColourFamily = "Blue",
                ColourFamilyId = 9,
                BrandName = "Waverly",
                BrandId = 1,
                Expiry = "07/27",
                SerialNumber = "ABCDEFG",
                DateAdded = DateTime.Parse("0001-01-01T00:00:00"), 
                DateDeleted = null, 
                DateModified = DateTime.Parse("0001-01-01T00:00:00")
            };

            //Act

            Library.MapUpdatedColourModel(Colours, expected);

            var actual = Library.GetById(Colours, expected.Id);

            //Assert
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.ColourName, actual.ColourName);
            Assert.AreEqual(expected.ColourFamily, actual.ColourFamily);
            Assert.AreEqual(expected.ColourFamilyId, actual.ColourFamilyId);
            Assert.AreEqual(expected.BrandName, actual.BrandName);
            Assert.AreEqual(expected.BrandId, actual.BrandId);
            Assert.AreEqual(expected.Expiry, actual.Expiry);
            Assert.AreEqual(expected.SerialNumber, actual.SerialNumber);
            Assert.AreEqual(expected.DateAdded, actual.DateAdded);
            Assert.AreEqual(expected.DateDeleted, actual.DateDeleted);
            Assert.AreEqual(expected.DateModified, actual.DateModified);
        }
    }
}
