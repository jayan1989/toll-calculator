using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TollCalculator.API.Data;
using TollCalculator.API.Services;

namespace TollCalculator.Tests.ServiceTests
{
    [TestClass]
    public class DateServiceTests
    {
        private readonly IHolidaysDataStore _holidaysDataStore;
        private readonly IDateService _dateService;

        public DateServiceTests()
        {
            _holidaysDataStore = new HolidaysDataStore();
            _dateService = new DateService(_holidaysDataStore);
        }

        [TestMethod]
        public void GivenIsTollFreeDate_WhenDateIsWeekEndDate_ThenShouldReturnTrue()
        {
            //Arrange
            var date = new DateTime(2022, 05, 28);

            //Act
            var response = _dateService.IsTollFreeDate(date);


            //Assert
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void GivenIsTollFreeDate_WhenDateIsHoliday_ThenShouldReturnTrue()
        {
            //Arrange
            var date = new DateTime(2022, 01, 1);

            //Act
            var response = _dateService.IsTollFreeDate(date);


            //Assert
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void GivenIsTollFreeDate_WhenDateIsNotHoliday_ThenShouldReturnTrue()
        {
            //Arrange
            var date = new DateTime(2022, 05, 27);

            //Act
            var response = _dateService.IsTollFreeDate(date);


            //Assert
            Assert.IsFalse(response);
        }

        [TestMethod]
        public void GivenIsTollFreeDate_WhenDateIsInAllDaysHolidaysMonth_ThenShouldReturnTrue()
        {
            //Arrange
            var date = new DateTime(2022, 07, 1);

            //Act
            var response = _dateService.IsTollFreeDate(date);


            //Assert
            Assert.IsTrue(response);
        }
    }
}